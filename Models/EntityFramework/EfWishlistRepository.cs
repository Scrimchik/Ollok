using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    public class EfWishlistRepository : IWhishlistrepository
    {
        private ApplicationDbContext db;

        public EfWishlistRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Wishlist> Wishlists => db.Wishlists;
    }
}
