using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.DTO.Auth
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
