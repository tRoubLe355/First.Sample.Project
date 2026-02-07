namespace Natura.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }
        public string? Unit { get; set; } // kg, adet, paket vb.
        public bool IsFeatured { get; set; }
        
        // Foreign Key
        public int CategoryId { get; set; }
        
        // Navigation
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
