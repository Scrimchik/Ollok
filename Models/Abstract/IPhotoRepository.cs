using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface IPhotoRepository
    {
        IQueryable<Photo> Photos { get; }

        Task DeletePhotoAsync(int id);
    }
}
