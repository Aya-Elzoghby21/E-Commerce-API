using System.ComponentModel.DataAnnotations;

namespace E_commerce.DTOs.CategoryDTOs
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Category name can't exceed 100 characters")]
        public string Name { get; set; }
      
            public string Description { get; set; }
        

    }
}
