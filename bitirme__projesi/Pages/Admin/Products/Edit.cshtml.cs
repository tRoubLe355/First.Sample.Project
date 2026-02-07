using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Natura.Entity;
using Natura.Service;

namespace bitirme__projesi.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public EditModel(IProductService productService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public SelectList? CategoryList { get; set; }
        public string? CurrentImageUrl { get; set; }

        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxFileSize = 5 * 1024 * 1024; // 5MB

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return RedirectToPage("/Admin/Products/Index");
            }

            Product = product;
            CurrentImageUrl = product.ImageUrl;
            var categories = await _categoryService.GetAllCategoriesAsync();
            CategoryList = new SelectList(categories, "Id", "Name", Product.CategoryId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                CategoryList = new SelectList(categories, "Id", "Name");
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                if (ImageFile.Length > MaxFileSize)
                {
                    ModelState.AddModelError("ImageFile", "Dosya boyutu en fazla 5MB olabilir.");
                    var categories = await _categoryService.GetAllCategoriesAsync();
                    CategoryList = new SelectList(categories, "Id", "Name");
                    return Page();
                }

                var extension = Path.GetExtension(ImageFile.FileName).ToLowerInvariant();
                if (!AllowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Sadece .jpg, .jpeg, .png ve .webp dosyaları yüklenebilir.");
                    var categories = await _categoryService.GetAllCategoriesAsync();
                    CategoryList = new SelectList(categories, "Id", "Name");
                    return Page();
                }

                var fileName = Guid.NewGuid() + extension;
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "products");
                Directory.CreateDirectory(uploadsFolder);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                Product.ImageUrl = $"/uploads/products/{fileName}";
            }

            await _productService.UpdateProductAsync(Product);
            return RedirectToPage("/Admin/Products/Index");
        }
    }
}
