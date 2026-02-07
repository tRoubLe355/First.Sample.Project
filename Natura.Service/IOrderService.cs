using Natura.Entity;

namespace Natura.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(string userId, string shippingAddress, string shippingCity, string shippingPostalCode, string shippingPhone);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
    }
}
