using DemoSecurity.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoSecurity.API.DTO
{
    public class UserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(4)]
        public string Password { get; set; } = null!;

        [Required]
        public UserRole Role { get; set; }
    }
}
