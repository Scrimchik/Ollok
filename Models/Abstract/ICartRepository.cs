using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface ICartRepository
    {
        IQueryable<Cart> Carts{ get; }
    }
}
