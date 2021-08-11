using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    class EfOrderRepository : IOrderRepository
    {
        private ApplicationDbContext db;

        public EfOrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Order> Orders => db.Orders.Include(t => t.Cart);

        public async Task<Order> GetOrderAsync(int id)
        {
            return await db.Orders.FindAsync(id);
        }

        public async Task ChangeOrderStatusAsync(int id, string status)
        {
            Order order = await GetOrderAsync(id);
            order.Status = status;
            await db.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
        }
    }
}
