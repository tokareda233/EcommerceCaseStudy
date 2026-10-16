using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Order>  ?Orders { get; set; }
    }
}
