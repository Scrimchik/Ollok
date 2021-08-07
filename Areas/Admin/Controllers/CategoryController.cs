using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        private ApplicationDbContext db;

        public CategoryController(ApplicationDbContext context, ICategoryRepository categoryRepository)
        {
            db = context;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Category()
        {
            return View(categoryRepository.Categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> UpdateCategory(int categoryId)
        {
            return View(await categoryRepository.Categories.FirstOrDefaultAsync(t => t.Id == categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            db.Categories.Remove(new Category() { Id = categoryId });
            await db.SaveChangesAsync();
            return RedirectToAction("Category");
        }
    }
}
