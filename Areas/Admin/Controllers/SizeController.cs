using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SizeController : Controller
    {
        private ISizeRepository sizeRepository;
        private ApplicationDbContext db;

        public SizeController(ISizeRepository sizeRepository, ApplicationDbContext context)
        {
            db = context;
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
            db.Sizes.Add(size);
            await db.SaveChangesAsync();
            return RedirectToAction("Size");
        }

        public async Task<IActionResult> UpdateSizeAsync(int sizeId)
        {
            return View(await sizeRepository.Sizes.FirstOrDefaultAsync(t => t.Id == sizeId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSizeAsync(Size size)
        {
            db.Entry(size).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Size");
        }

        public async Task<IActionResult> DeleteSizeAsync(int sizeId)
        {
            db.Sizes.Remove(new Size() { Id = sizeId });
            await db.SaveChangesAsync();
            return RedirectToAction("Size");
        }
    }
}
