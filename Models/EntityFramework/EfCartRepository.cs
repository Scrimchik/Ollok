using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    public class EfCartRepository : ICartRepository
    {
        private ApplicationDbContext db;

        public EfCartRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Cart> Carts => db.Carts;
    }
}
