using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    public class EfSizeRepository : ISizeRepository
    {
        private ApplicationDbContext db;

        public EfSizeRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Size> Sizes => db.Sizes;

        public async Task<Size> GetSizeAsync(int id)
        {
            return await db.Sizes.FindAsync(id);
        }

        public async Task AddSizeAsync(Size size)
        {
            db.Sizes.Add(size);
            await db.SaveChangesAsync();
        }

        public async Task UpdateSizeAsync(Size size)
        {
            Size unUpdatedSize = await GetSizeAsync(size.Id);
            unUpdatedSize.SizeValue = size.SizeValue;
            await db.SaveChangesAsync();
        }

        public async Task DeleteSizeAsync(Size size)
        {
            db.Sizes.Remove(size);
            await db.SaveChangesAsync();
        }
    }
}
