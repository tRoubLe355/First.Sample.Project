using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;

        public IndexModel(IProductService productService, ICategoryService categoryService, ICartService cartService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _cartService = cartService;
        }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int? SelectedCategoryId { get; set; }
        public string? SearchQuery { get; set; }
        public int TotalProducts => Products.Count();

        public async Task OnGetAsync(int? categoryId, string? searchQuery)
        {
            SelectedCategoryId = categoryId;
            SearchQuery = searchQuery;
            Categories = await _categoryService.GetAllCategoriesAsync();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                Products = await _productService.SearchProductsAsync(searchQuery);
                if (categoryId.HasValue)
                {
                    Products = Products.Where(p => p.CategoryId == categoryId.Value);
                }
            }
            else if (categoryId.HasValue)
            {
                Products = await _productService.GetProductsByCategoryAsync(categoryId.Value);
            }
            else
            {
                Products = await _productService.GetAllProductsAsync();
            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return RedirectToPage("/Account/Login", new { returnUrl = "/Products/Index" });
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                await _cartService.AddToCartAsync(userId, productId, 1);
            }

            return RedirectToPage();
        }
    }
}
