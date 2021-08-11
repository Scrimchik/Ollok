using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface ICartLineRepository
    {
        IQueryable<CartLine> CartLines { get; }

        Task AddCartlineAsync(CartLine cartLine);
        Task DeleteCartlineAsync(CartLine cartline);
        Task AddProductCountAsync(int cartlineId);
        Task RemoveProductCountAsync(int cartlineId);
    }
}
