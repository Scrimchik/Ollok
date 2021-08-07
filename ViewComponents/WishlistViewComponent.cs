using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using System.Linq;

namespace Ollok.ViewComponents
{
    public class WishlistViewComponent : ViewComponent
    {
        private ApplicationDbContext db;

        public WishlistViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Wishlists?.Where(t => t.Id == HttpContext.Request.Cookies["wishlist_id"]).Include(t => t.Products).ThenInclude(t => t.Photos).Include(t => t.Products).ThenInclude(t => t.Sizes).Select(t => t.Products).FirstOrDefault());
        }
    }
}
