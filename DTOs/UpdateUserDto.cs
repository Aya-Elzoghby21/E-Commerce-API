using System.ComponentModel.DataAnnotations;

namespace E_commerce.DTOs
{
    public class UpdateUserDto
    {

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100)]
            public string Address { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Required]
            public List<string> Roles { get; set; }
        }
}
