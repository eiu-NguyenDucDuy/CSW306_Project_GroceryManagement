using System.ComponentModel.DataAnnotations;

namespace GroceryManagement.DTOs.Auth
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
