using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity can't be negative")]
        public int StockQuantity { get; set; }
        public string Urlimage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImage> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
