using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;

        public IndexModel(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
        public int OrderCount { get; set; }
        public int PendingOrderCount { get; set; }
        public IEnumerable<Order> RecentOrders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            var orders = await _orderService.GetAllOrdersAsync();

            ProductCount = products.Count();
            CategoryCount = categories.Count();
            OrderCount = orders.Count();
            PendingOrderCount = orders.Count(o => o.Status == OrderStatus.Pending);
            RecentOrders = orders.Take(5);
        }
    }
}
