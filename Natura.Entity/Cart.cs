namespace Natura.Entity
{
    public class Cart : BaseEntity
    {
        // Foreign Key
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual AppUser? User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        
        // Hesaplanan özellik
        public decimal TotalAmount => CartItems?.Sum(x => x.TotalPrice) ?? 0;
    }
}
