using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.DTO.Category
{
    public class CreateCategoryDTO
    {
       
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
