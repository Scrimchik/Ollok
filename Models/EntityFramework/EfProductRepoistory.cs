using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    public class EfProductRepoistory : IProductRepository
    {
        private ApplicationDbContext db;

        public EfProductRepoistory(ApplicationDbContext context)
        {
            db = context;
        }

        public IQueryable<Product> Products => db.Products;
    }
}
