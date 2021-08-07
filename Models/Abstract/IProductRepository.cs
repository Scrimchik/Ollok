using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
