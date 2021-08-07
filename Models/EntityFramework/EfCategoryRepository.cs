using Ollok.Models.Abstract;
using System.Linq;

namespace Ollok.Models.EntityFramework
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext db;

        public EfCategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Category> Categories => db.Categories;

        public Category GetCategoryByName(string CategoryName)
        {
            return Categories.FirstOrDefault(t => t.LatinName == CategoryName);
        }
    }
}
