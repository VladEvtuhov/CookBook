using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.WEB.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [MinLength(6, ErrorMessage ="Password length should be more than 6 characters")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
