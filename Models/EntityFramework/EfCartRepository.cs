using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task AddCartAsync(Cart cart)
        {
            db.Carts.Add(cart);
            await db.SaveChangesAsync();
        }
    }
}
