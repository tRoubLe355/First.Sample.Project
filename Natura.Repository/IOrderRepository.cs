using Natura.Entity;

namespace Natura.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId);
        Task<Order?> GetOrderWithItemsAsync(int id);
        Task<IEnumerable<Order>> GetOrdersWithItemsAsync();
    }
}
