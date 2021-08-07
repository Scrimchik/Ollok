using Microsoft.AspNetCore.Mvc;
using Ollok.Models;

namespace Ollok.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public CategoryListViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Categories);
        }
    }
}
