using Natura.Entity;

namespace Natura.Repository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByUserAsync(string userId);
        Task<Cart?> GetCartWithItemsAsync(int id);
    }
}
