namespace Natura.Entity
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        
        // Foreign Keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        
        // Navigation
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
