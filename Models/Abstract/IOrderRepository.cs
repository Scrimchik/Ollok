using System.Linq;

namespace Ollok.Models.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
    }
}
