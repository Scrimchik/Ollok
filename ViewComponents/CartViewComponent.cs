using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System.Linq;

namespace Ollok.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public ICartRepository cartRepository;

        public CartViewComponent(ICartRepository cart)
        {
            cartRepository = cart;
        }

        public IViewComponentResult Invoke()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            Cart cart = cartRepository.Carts.Where(t => t.Id == cartId)
                .Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos)
                .Include(t => t.CartLines).ThenInclude(t => t.Product.Category)
                .FirstOrDefault();

            return View(new CartViewModel { 
                Cart = cart
            });
        }
    }
}
