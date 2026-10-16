using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.DTO.Order
{
    public class CreateOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TatalAmout { get; set; }
       
        public int UserId { get; set; }



        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
       
        public int OrderId { get; set; }
       
        public int ProductId { get; set; }
    }
}
