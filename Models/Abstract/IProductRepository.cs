using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Task<Product> GetProductAsync(int id);
        Task<Product> GetProductByNameAsync(string productName);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task ShowProductAsync(int productId);
        Task HideProductAsync(int productId);
        Task AddLikeToProductAsync(Product product);
        Task RemoveLikeFromProductAsync(Product product);
    }
}
