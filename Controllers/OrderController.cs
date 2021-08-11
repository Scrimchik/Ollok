using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ollok.Models;
using Ollok.Models.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Controllers
{
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;

        public OrderController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task<IActionResult> Order()
        {
            string cartId = HttpContext.Request.Cookies["cartId"];
            Order order = new Order();
            Cart cart = await cartRepository.Carts.Where(t => t.Id == cartId)
                .Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync();
            order.Cart = cart;
            return View(order);
        }

        public async Task<IActionResult> AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Delete("cartId");
                TempData["OrderNotification"] = "Заказ оформлен, мы свяжемся с вами в ближайшее время";
                return RedirectToAction("List", "Product");
            }
            order.Cart = await cartRepository.Carts.Where(t => t.Id == order.CartId)
                .Include(t => t.CartLines).ThenInclude(t => t.Product).ThenInclude(t => t.Photos).FirstOrDefaultAsync();
            return View("Order", order);
        }
    }
}
