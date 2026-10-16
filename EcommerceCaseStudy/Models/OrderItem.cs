using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceCaseStudy.Models
{
    public class OrderItem
    {
        /*
         Id int Primary Key
Quantity int Required, From 1–1000
UnitPrice decimal Required, From 0.01–1,000,000;
         
         */

        public int Id { get; set; }
        [Required]
        [Range(1,1000)]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01,1000000)]
        public decimal UnitPrice { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order ?Order { get; set; }
        [ForeignKey("Product")]
        public int ProductId {  get; set; }
        public Product ?Product {  get; set; }
    }
}
