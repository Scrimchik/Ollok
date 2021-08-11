using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        Category GetCategory(int id);
        Task<Category> GetCategoryByNameAsync(string categoryLatinName);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);   
    }
}
