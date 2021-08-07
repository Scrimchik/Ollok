using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        public Category GetCategoryByName(string CategoryName);
    }
}
