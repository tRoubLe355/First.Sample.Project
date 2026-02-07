using Natura.Entity;
using Natura.Repository;

namespace Natura.Service
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _unitOfWork.Carts.GetCartByUserAsync(userId);
        }

        public async Task<Cart> GetOrCreateCartAsync(string userId)
        {
            var cart = await _unitOfWork.Carts.GetCartByUserAsync(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
            }
            return cart;
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            
            if (product == null) return;

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.DiscountPrice ?? product.Price,
                    CreatedAt = DateTime.UtcNow
                };
                cart.CartItems.Add(cartItem);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(string userId, int productId, int quantity)
        {
            var cart = await _unitOfWork.Carts.GetCartByUserAsync(userId);
            if (cart == null) return;

            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    cart.CartItems.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                    item.UpdatedAt = DateTime.UtcNow;
                }
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCartAsync(string userId, int productId)
        {
            var cart = await _unitOfWork.Carts.GetCartByUserAsync(userId);
            if (cart == null) return;

            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (item != null)
            {
                cart.CartItems.Remove(item);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await _unitOfWork.Carts.GetCartByUserAsync(userId);
            if (cart == null) return;

            cart.CartItems.Clear();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
