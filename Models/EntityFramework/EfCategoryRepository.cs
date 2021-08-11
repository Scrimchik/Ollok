using Microsoft.EntityFrameworkCore;
using Ollok.Models.Abstract;
using System.Linq;
using System.Threading.Tasks;

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

        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public async Task<Category> GetCategoryByNameAsync(string categoryLatinName)
        {
            return await db.Categories.FirstOrDefaultAsync(t => t.LatinName == categoryLatinName);
        }

        public async Task AddCategoryAsync(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            Category unUpdatedCategory = GetCategory(category.Id);
            unUpdatedCategory.Name = category.Name;
            await db.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
        }
    }
}
