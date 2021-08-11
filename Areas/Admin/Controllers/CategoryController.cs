using Microsoft.AspNetCore.Mvc;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
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
            await categoryRepository.AddCategoryAsync(category);
            return RedirectToAction("Category");
        }

        [HttpPost]
        public IActionResult UpdateCategory(int categoryId)
        {
            return View(categoryRepository.GetCategory(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await categoryRepository.UpdateCategoryAsync(category);
            return RedirectToAction("Category");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            await categoryRepository.DeleteCategoryAsync(category);
            return RedirectToAction("Category");
        }
    }
}
