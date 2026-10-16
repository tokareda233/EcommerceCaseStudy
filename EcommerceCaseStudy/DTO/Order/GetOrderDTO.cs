using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCaseStudy.DTO.Order
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
    
        public DateTime OrderDate { get; set; }
        
        public string Status { get; set; }
       
        public decimal TatalAmout { get; set; }
      
        public int UserId { get; set; }


        public int OrderItemId { get; set; }
      
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }

      
        public int ProductId { get; set; }


    }
}
