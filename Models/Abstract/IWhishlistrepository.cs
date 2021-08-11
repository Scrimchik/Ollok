using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface IWhishlistrepository
    {
        IQueryable<Wishlist> Wishlists { get; }

        Task<Wishlist> GetWishlistAsync(string id);
        Task AddWishlistAsync(Wishlist wishlist);
        Task UpdateWishlistAsync(Wishlist wishlist);
    }
}
