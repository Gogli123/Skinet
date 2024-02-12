using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*\\W).{6,}$",
         ErrorMessage = "Password must have 1 Uppercase, Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; }
    }
}