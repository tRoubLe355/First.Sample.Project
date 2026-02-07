using Natura.Entity;

namespace Natura.Service
{
    public interface ICartService
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
        Task<Cart> GetOrCreateCartAsync(string userId);
        Task AddToCartAsync(string userId, int productId, int quantity);
        Task UpdateCartItemAsync(string userId, int productId, int quantity);
        Task RemoveFromCartAsync(string userId, int productId);
        Task ClearCartAsync(string userId);
    }
}
