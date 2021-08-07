using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface ICartLineRepository
    {
        IQueryable<CartLine> CartLines { get; }
    }
}
