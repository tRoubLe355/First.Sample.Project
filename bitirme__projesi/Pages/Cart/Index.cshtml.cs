using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;

        public IndexModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public Natura.Entity.Cart? Cart { get; set; }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                Cart = await _cartService.GetCartByUserIdAsync(userId);
            }
        }

        public async Task<IActionResult> OnPostUpdateQuantityAsync(int productId, int quantity)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                await _cartService.UpdateCartItemAsync(userId, productId, quantity);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveItemAsync(int productId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                await _cartService.RemoveFromCartAsync(userId, productId);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostClearCartAsync()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                await _cartService.ClearCartAsync(userId);
            }
            return RedirectToPage();
        }
    }
}
