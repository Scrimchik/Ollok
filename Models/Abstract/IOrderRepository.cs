using System.Linq;
using System.Threading.Tasks;

namespace Ollok.Models.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        Task<Order> GetOrderAsync(int id);
        Task ChangeOrderStatusAsync(int id, string status);
        Task DeleteOrderAsync(Order order);
    }
}
