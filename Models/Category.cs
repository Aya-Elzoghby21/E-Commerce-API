using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Category name can't exceed 100 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
