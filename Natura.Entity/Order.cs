namespace Natura.Entity
{
    public enum OrderStatus
    {
        Pending,        // Beklemede
        Processing,     // Hazırlanıyor
        Confirmed,      // Onaylandı
        Shipped,        // Kargoya verildi
        Delivered,      // Teslim edildi
        Cancelled       // İptal edildi
    }

    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        // Teslimat Bilgileri
        public string ShippingAddress { get; set; } = string.Empty;
        public string ShippingCity { get; set; } = string.Empty;
        public string ShippingPostalCode { get; set; } = string.Empty;
        public string ShippingPhone { get; set; } = string.Empty;
        
        // Foreign Key
        public string UserId { get; set; } = string.Empty;
        
        // Navigation
        public virtual AppUser? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
