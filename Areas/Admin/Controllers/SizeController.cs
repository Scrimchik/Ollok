using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private ISizeRepository sizeRepository;

        public SizeController(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public IActionResult Size()
        {
            return View(sizeRepository.Sizes);
        }

        public IActionResult AddSize()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSizeAsync(Size size)
        {
            await sizeRepository.AddSizeAsync(size);
            return RedirectToAction("Size");
        }

        public async Task<IActionResult> UpdateSizeAsync(int sizeId)
        {
            return View(await sizeRepository.GetSizeAsync(sizeId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSizeAsync(Size size)
        {
            await sizeRepository.UpdateSizeAsync(size);
            return RedirectToAction("Size");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSizeAsync(Size size)
        {
            await sizeRepository.DeleteSizeAsync(size);
            return RedirectToAction("Size");
        }
    }
}
