using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface ISizeRepository
    {
        IQueryable<Size> Sizes { get; }

        Task<Size> GetSizeAsync(int id);
        Task AddSizeAsync(Size size);
        Task UpdateSizeAsync(Size size);
        Task DeleteSizeAsync(Size size);
    }
}
