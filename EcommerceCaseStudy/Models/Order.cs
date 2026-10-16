using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceCaseStudy.Models
{
    public class Order
    {
        /*
         Model 4: Order
Property Data Type Validation / Requirement
Id int Primary Key
OrderDate DateTime Required;
Status string Required; Pending, Completed, or Cancelled
TotalAmount decimal Required;
         */

        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TatalAmout { get; set; }
        [ForeignKey("User")]
        
        public int UserId { get; set; }
        public User ?User { get; set; }
        public ICollection<OrderItem> ?orderItems { get; set; }
    }
}
