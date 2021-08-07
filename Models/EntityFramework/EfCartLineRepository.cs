using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    class EfCartLineRepository : ICartLineRepository
    {
        private ApplicationDbContext db;

        public EfCartLineRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<CartLine> CartLines => db.CartLines;
    }
}
