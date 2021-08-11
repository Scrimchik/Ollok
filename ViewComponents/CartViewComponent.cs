using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using Ollok.Models.ViewsModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public ICartRepository cartRepository;

        public CartViewComponent(ICartRepository cart)
        {
            cartRepository = cart;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            Cart cart = await cartRepository.Carts.Where(t => t.Id == cartId)
                .Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos)
                .Include(t => t.CartLines).ThenInclude(t => t.Product.Category)
                .FirstOrDefaultAsync();

            return View(new CartViewModel { 
                Cart = cart
            });
        }
    }
}
