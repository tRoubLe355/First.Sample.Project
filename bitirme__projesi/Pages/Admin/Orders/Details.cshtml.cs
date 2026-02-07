using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Order? Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await _orderService.GetOrderByIdAsync(id);
            if (Order == null)
            {
                return RedirectToPage("/Admin/Orders/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int orderId, string status)
        {
            if (Enum.TryParse<OrderStatus>(status, out var newStatus))
            {
                await _orderService.UpdateOrderStatusAsync(orderId, newStatus);
            }
            return RedirectToPage(new { id = orderId });
        }
    }
}
