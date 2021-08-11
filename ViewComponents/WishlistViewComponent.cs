using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.ViewComponents
{
    public class WishlistViewComponent : ViewComponent
    {
        private IWhishlistrepository whishlistrepository;

        public WishlistViewComponent(IWhishlistrepository whishlistrepository)
        {
            this.whishlistrepository = whishlistrepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string wishlistId = HttpContext.Request.Cookies["wishlist_id"];
            Wishlist wishlist = await whishlistrepository.GetWishlistAsync(wishlistId);
            return View(wishlist?.Products);
        }
    }
}
