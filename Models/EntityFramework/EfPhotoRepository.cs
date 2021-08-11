using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.EntityFramework
{
    public class EfPhotoRepository : IPhotoRepository
    {
        private ApplicationDbContext db;

        public EfPhotoRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Photo> Photos => db.Photos;

        public async Task DeletePhotoAsync(int id)
        {
            db.Photos.Remove(new Photo { Id = id });
            await db.SaveChangesAsync();
        }
    }
}
