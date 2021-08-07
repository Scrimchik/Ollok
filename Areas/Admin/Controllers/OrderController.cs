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
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private ApplicationDbContext db;

        public OrderController(IOrderRepository orderRepository, ApplicationDbContext db)
        {
            this.orderRepository = orderRepository;
            this.db = db;
        }
        public async Task<IActionResult> OrderList(string status)
        {
            return View(await orderRepository.Orders.Where(t => status == null || t.Status == status).ToListAsync());
        }

        public async Task<IActionResult> Order(int orderId)
        {
            return View(await orderRepository.Orders.Where(t => t.Id == orderId).Include(t => t.Cart).ThenInclude(t => t.CartLines)
                .ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> ChangeStatus(string status, int orderId)
        {
            Order order = await orderRepository.Orders.FirstOrDefaultAsync(t => t.Id == orderId);
            order.Status = status;
            await db.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> FindOrder(int orderId)
        {
            return View("OrderList", await orderRepository.Orders.Where(t => t.Id == orderId).ToListAsync());
        }
    }
}
