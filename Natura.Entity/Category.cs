namespace Natura.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        
        // Navigation
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
