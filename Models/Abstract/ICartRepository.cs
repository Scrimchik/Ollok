using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface ICartRepository
    {
        IQueryable<Cart> Carts{ get; }

        Task AddCartAsync(Cart cart);
    }
}
