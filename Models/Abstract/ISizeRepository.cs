using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface ISizeRepository
    {
        IQueryable<Size> Sizes { get; }
    }
}
