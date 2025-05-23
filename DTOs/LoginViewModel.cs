using System.ComponentModel.DataAnnotations;

namespace E_commerce.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
