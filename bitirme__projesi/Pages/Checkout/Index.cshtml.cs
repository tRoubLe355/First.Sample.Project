using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Checkout
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public IndexModel(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        public Natura.Entity.Cart? Cart { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Adres gereklidir")]
            [Display(Name = "Adres")]
            public string ShippingAddress { get; set; } = string.Empty;

            [Required(ErrorMessage = "Şehir gereklidir")]
            [Display(Name = "Şehir")]
            public string ShippingCity { get; set; } = string.Empty;

            [Required(ErrorMessage = "Posta kodu gereklidir")]
            [Display(Name = "Posta Kodu")]
            public string ShippingPostalCode { get; set; } = string.Empty;

            [Required(ErrorMessage = "Telefon gereklidir")]
            [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
            [Display(Name = "Telefon")]
            public string ShippingPhone { get; set; } = string.Empty;
        }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                Cart = await _cartService.GetCartByUserIdAsync(userId);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Cart = await _cartService.GetCartByUserIdAsync(userId);

            if (Cart == null || !Cart.CartItems.Any())
            {
                ModelState.AddModelError(string.Empty, "Sepetiniz boş.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var order = await _orderService.CreateOrderAsync(
                    userId,
                    Input.ShippingAddress,
                    Input.ShippingCity,
                    Input.ShippingPostalCode,
                    Input.ShippingPhone
                );

                return RedirectToPage("/Checkout/Success", new { orderId = order.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Sipariş oluşturulurken bir hata oluştu: " + ex.Message);
                return Page();
            }
        }
    }
}
