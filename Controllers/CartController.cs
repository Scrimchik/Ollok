using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository cartRepository;
        private ICartLineRepository cartLineRepository;

        public CartController(ICartRepository cart, ICartLineRepository cartLineRepository)
        {
            cartRepository = cart;
            this.cartLineRepository = cartLineRepository;
        }

        public async Task<IActionResult> AddProductToCart(int productId, int sizeValue)
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            Cart cart;
            if (cartId == null)
            {
                cart = new Cart { Id = Guid.NewGuid().ToString() };
                HttpContext.Response.Cookies.Append("cartId", cart.Id);
            }
            else
                cart = await cartRepository.Carts.Include(t => t.CartLines).ThenInclude(t => t.Product).FirstOrDefaultAsync(t => t.Id == cartId);   
            
            if (!cart.CartLines.Any(t => t.Product.Id == productId)) 
            { 
                CartLine cartLine = new CartLine() { Cart = cart, ProductId = productId, SizeValue = sizeValue, ProductSum = 1 };
                await cartLineRepository.AddCartlineAsync(cartLine);
            }
            
            return StatusCode(200);
        }

        public IActionResult GetCart()
        {
            return ViewComponent("Cart");
        }

        public async Task<IActionResult> DeleteProductFromCart(int cartLineId)
        {
            await cartLineRepository.DeleteCartlineAsync(new CartLine { Id = cartLineId });
            return ViewComponent("Cart");
        }

        public async Task<IActionResult> DeleteProductFromCartOrder(int cartlineId)
        {
            await cartLineRepository.DeleteCartlineAsync(new CartLine { Id = cartlineId });
            return RedirectToAction("Order", "Order");
        }

        public async Task<IActionResult> AddProductCount(int cartLineId)
        {
            await cartLineRepository.AddProductCountAsync(cartLineId);
            return ViewComponent("Cart");
        }

        public async Task<IActionResult> RemoveProductCount(int cartLineId)
        {
            await cartLineRepository.RemoveProductCountAsync(cartLineId);
            return ViewComponent("Cart");
        }

        public async Task<int> GetCartCount()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            return cartId == null ? 0 : await cartLineRepository.CartLines.Where(t => t.CartId == cartId).CountAsync();
        }
    }
}
