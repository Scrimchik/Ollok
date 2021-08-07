using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface IWhishlistrepository
    {
        IQueryable<Wishlist> Wishlists { get; }
    }
}
