using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
