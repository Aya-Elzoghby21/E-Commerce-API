using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string address { get; set; }

  

    [Required]
    [EmailAddress]
    public override string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<WishlistItem> Wishlist { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
