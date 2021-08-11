using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
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

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(string status, int orderId)
        {
            await orderRepository.ChangeOrderStatusAsync(orderId, status);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> FindOrder(int orderId)
        {
            return View("OrderList", await orderRepository.GetOrderAsync(orderId));
        }

        public async Task<IActionResult> DeleteOrder(Order order)
        {
            await orderRepository.DeleteOrderAsync(order);
            return RedirectToAction("OrderList");
        }
    }
}
