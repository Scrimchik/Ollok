using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    class EfCartLineRepository : ICartLineRepository
    {
        private ApplicationDbContext db;

        public EfCartLineRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<CartLine> CartLines => db.CartLines.Include(t => t.Product).Include(t => t.Product.Category)
            .Include(t => t.Product.Photos).Include(t => t.Product.Sizes);

        public async Task AddCartlineAsync(CartLine cartLine)
        {
            db.CartLines.Add(cartLine);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCartlineAsync(CartLine cartline)
        {
            db.CartLines.Remove(cartline);
            await db.SaveChangesAsync();
        }

        public async Task AddProductCountAsync(int cartlineId)
        {
            CartLine cartLine = await db.CartLines.FindAsync(cartlineId);
            cartLine.ProductSum++;
            await db.SaveChangesAsync();
        }

        public async Task RemoveProductCountAsync(int cartlineId)
        {
            CartLine cartLine = await db.CartLines.FindAsync(cartlineId);
            cartLine.ProductSum--;
            await db.SaveChangesAsync();
        }
    }
}
