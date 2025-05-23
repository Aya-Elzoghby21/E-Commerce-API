using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        public string? DiscountReason { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } 

        public ICollection<OrderItem> OrderItems { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public Payment Payment { get; set; }
    }
}
