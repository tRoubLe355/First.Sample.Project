using Microsoft.AspNetCore.Mvc.RazorPages;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> FeaturedProducts { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            FeaturedProducts = await _productService.GetFeaturedProductsAsync();
        }
    }
}
