using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    public class EfWishlistRepository : IWhishlistrepository
    {
        private ApplicationDbContext db;

        public EfWishlistRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Wishlist> Wishlists => db.Wishlists.Include(t => t.Products);

        public async Task<Wishlist> GetWishlistAsync(string id)
        {
            return await db.Wishlists.Include(t => t.Products).ThenInclude(t => t.Photos).Include(t => t.Products)
                .ThenInclude(t => t.Sizes).Include(t => t.Products).ThenInclude(t => t.Category).
                FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddWishlistAsync(Wishlist wishlist)
        {
            db.Wishlists.Add(wishlist);
            await db.SaveChangesAsync();
        }

        public async Task UpdateWishlistAsync(Wishlist wishlist)
        {
            Wishlist unUpdateWishlist = db.Wishlists.Find(wishlist.Id);
            wishlist.Products = wishlist.Products;
            await db.SaveChangesAsync();
        }
    }
}
