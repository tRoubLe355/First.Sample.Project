using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Checkout
{
    [Authorize]
    public class SuccessModel : PageModel
    {
        private readonly IOrderService _orderService;

        public SuccessModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Order? Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            Order = await _orderService.GetOrderByIdAsync(orderId);

            if (Order == null)
            {
                return RedirectToPage("/Orders/Index");
            }

            // Güvenlik: Sadece kendi siparişini görebilsin
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (Order.UserId != userId)
            {
                return RedirectToPage("/Orders/Index");
            }

            return Page();
        }
    }
}
