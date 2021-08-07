using Ollok.Models.Abstract;
using System.Linq;

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
    }
}
