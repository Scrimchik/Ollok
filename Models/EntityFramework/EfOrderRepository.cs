using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    class EfOrderRepository : IOrderRepository
    {
        private ApplicationDbContext db;

        public EfOrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Order> Orders => db.Orders;
    }
}
