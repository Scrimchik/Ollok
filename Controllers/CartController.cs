using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository cartRepository;
        private ICartLineRepository cartLineRepository;
        private ApplicationDbContext db;

        public CartController(ICartRepository cart, ApplicationDbContext context, ICartLineRepository cartLineRepository)
        {
            cartRepository = cart;
            db = context;
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
                await db.Carts.AddAsync(cart);
            }
            else
                cart = await cartRepository.Carts.Include(t => t.CartLines).ThenInclude(t => t.Product).FirstOrDefaultAsync(t => t.Id == cartId);   
            
            if (!cart.CartLines.Any(t => t.Product.Id == productId)) 
            { 
                CartLine cartLine = new CartLine() { CartId = cart.Id, ProductId = productId, SizeValue = sizeValue, ProductSum = 1 };
                cart.CartLines.Add(cartLine);
            }
            
            
            await db.SaveChangesAsync();
            return StatusCode(200);
        }

        public async Task<IActionResult> GetCart()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            Cart cart = await cartRepository.Carts.Where(t => t.Id == cartId)
                .Include(t => t.CartLines).ThenInclude(t => t.Product)
                .ThenInclude(t => t.Photos).Include(t => t.CartLines).ThenInclude(t => t.Product.Category)
                .FirstOrDefaultAsync();
            return ViewComponent("Cart", new CartViewModel { Cart = cart });
        }

        public async Task<IActionResult> DeleteProductFromCart(int cartLineId)
        {
            Cart cart = await DeleteProductAsync(cartLineId);
            return ViewComponent("Cart", new CartViewModel() { Cart = cart });
        }

        public async Task<IActionResult> DeleteProductFromCartOrder(int productId)
        {
            await DeleteProductAsync(productId);
            return RedirectToAction("Order", "Order");
        }

        public async Task<IActionResult> AddProductCount(int cartLineId)
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            CartLine cartSize = await cartLineRepository.CartLines.FirstOrDefaultAsync(t => t.Id == cartLineId);
            cartSize.ProductSum += 1;
            await db.SaveChangesAsync();
            return ViewComponent("Cart", new CartViewModel() { Cart = await cartRepository.Carts.Where(t => t.Id == cartId).Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync() });
        }

        public async Task<IActionResult> RemoveProductCount(int cartLineId)
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            CartLine cartLine = await cartLineRepository.CartLines.FirstOrDefaultAsync(t => t.Id == cartLineId); 
            cartLine.ProductSum -= 1;
            await db.SaveChangesAsync();
            return ViewComponent("Cart", new CartViewModel() { Cart = await cartRepository.Carts.Where(t => t.Id == cartId).Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync() });
        }

        public async Task<int> GetCartCount()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            return cartId == null ? 0 : await cartLineRepository.CartLines.Where(t => t.CartId == cartId).CountAsync();
        }

        public async Task<Cart> DeleteProductAsync(int cartLineId)
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            CartLine deleteCartLine = await cartLineRepository.CartLines.FirstOrDefaultAsync(t => t.Id == cartLineId);
            Cart cart = await cartRepository.Carts.Where(t => t.Id == cartId).Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync();
            db.CartLines.Remove(deleteCartLine);
            await db.SaveChangesAsync();
            return cart;
        }
    }
}
