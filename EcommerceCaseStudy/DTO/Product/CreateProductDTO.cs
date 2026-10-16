using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.DTO.Product
{
    public class CreateProductDTO
    {
       
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 1000000)]
        public int StockQuantity { get; set; }
       
        public int CategoryId { get; set; }
    }
}
