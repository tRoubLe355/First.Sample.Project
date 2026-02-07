using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Natura.Entity;

namespace Natura.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product - Category ilişkisi
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order - User ilişkisi
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderItem - Order ilişkisi
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderItem - Product ilişkisi
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cart - User ilişkisi
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // CartItem - Cart ilişkisi
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // CartItem - Product ilişkisi
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision ayarları
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.DiscountPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.UnitPrice)
                .HasPrecision(18, 2);

            // Seed Data - Kategoriler
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sebzeler", Description = "Taze organik sebzeler", CreatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "Meyveler", Description = "Taze organik meyveler", CreatedAt = DateTime.UtcNow },
                new Category { Id = 3, Name = "Mutfak", Description = "Mutfak ürünleri", CreatedAt = DateTime.UtcNow },
                new Category { Id = 4, Name = "Baharatlar", Description = "Taze baharatlar ve otlar", CreatedAt = DateTime.UtcNow }
            );

            // Seed Data - Ürünler
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Organik Avokado", Description = "Premium organik avokadolar", Price = 89.99m, Stock = 100, Unit = "kg", CategoryId = 1, IsFeatured = true, ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCFpqN459_0PlgdAkXVkCmWHPExM2qMPsddTfngX2WUrqTTimQKyEYuBeOvo4BsqW3sgtqJyBr3ZN4_rIW7Y3WarclJlYvrrQ1NmdQuuaRGBLbmTjQoGKbwYsyARypoKOFzcTdZjdWHIjZo4IOqiebV-BlZMWiWAgaJWtbC0Hm78-m6PMjwLOjRab7wWRUx4RRMs3G2DYDluW_ZVjo6-RVH4BeSbUEDQf9y0tU6H92cAirMPhgO5nni9a6ElPtGhCVK4tzuTy73XmCn", CreatedAt = DateTime.UtcNow },
                new Product { Id = 2, Name = "Doğal Bal", Description = "Saf köy balı", Price = 249.99m, Stock = 50, Unit = "kavanoz", CategoryId = 3, IsFeatured = true, ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBLkPQO9DbWrX2cKM4JYn_wck1sq4JBSzpgo4YUuIllMIckGbwDvyayFo-PfT8pRkSuoV1AmJFmlUk5Wq0a-WsW0ObDdMMuRq8g29YLJXfhfY0S32ix7S1eGkTXn1_Q-baqIYVT3raXZfAJ4VvQTC9OhTpCHDxo1VyweSvowyqamUBVuPiccdD6SgbNExZvajwBitCrYX5JWDq5mWdUPixFZLVx69j4MUjuNnD1dc0OCLb1hxW_8BgepM4FsNrvFNK3xZErOzg-lT7E", CreatedAt = DateTime.UtcNow },
                new Product { Id = 3, Name = "Köy Domatesi", Description = "Taze köy domatesi", Price = 45.00m, Stock = 80, Unit = "kg", CategoryId = 1, IsFeatured = true, ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBFN0XQTtzpdkv94-wSCgXgeZdRcwSztZ5DuXUoaNZ_BmNf8u96PR_WYwwr8A-j9HR9JNJUF3JI7P3eOHdWIcJnKBWnYtqmnnnxrg1aoJJNvYNkojLeymBcqFryLC40qtWbgKmZBPXo-S9cYvePm59po_XR-bJKaBYGIwKGBmN7PDifyMjb-Vc1drGL9Vk4tZF23cS1I7MNmFKS-Ep6kJD1RBXtkw_QQ62al4cTdHchje7Br8eseTAeGVcUoCH5vCVYpQryTx6MYUx2", CreatedAt = DateTime.UtcNow },
                new Product { Id = 4, Name = "Taze Fesleğen", Description = "Aromatik taze fesleğen", Price = 25.00m, Stock = 120, Unit = "demet", CategoryId = 4, IsFeatured = true, ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCdlGsBSbVaTa4-Y8Fnnl7lDNITZJog5fswkBffpwqIiO94LSNtK3bP2cjCIuOI67F8tQRVSmknWf2v3M3WjtwuPwDK6SYwY-bQLCbQ6oWqRH5DmECxISeL7hhTawaD4v2kuuYISv5uwPofOs9-g_gtnT6ahFH64yxu2sutCzKdVvE6tnC8hWFTU2b6dfvTHgB3o2io4uoD5Yhpkgv-SPjkYwaSlhr6ebMdWLMDbuXHob9avgLcReAPCnBZCNzKqtQnzkVMeq1JRikw", CreatedAt = DateTime.UtcNow },
                new Product { Id = 5, Name = "Organik Elma", Description = "Taze organik elmalar", Price = 35.99m, Stock = 150, Unit = "kg", CategoryId = 2, IsFeatured = false, ImageUrl = "", CreatedAt = DateTime.UtcNow },
                new Product { Id = 6, Name = "Organik Portakal", Description = "Sulu organik portakallar", Price = 42.50m, Stock = 100, Unit = "kg", CategoryId = 2, IsFeatured = false, ImageUrl = "", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
