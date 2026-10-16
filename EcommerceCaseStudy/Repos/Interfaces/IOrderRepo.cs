using EcommerceCaseStudy.DTO.Order;
using EcommerceCaseStudy.Models;

namespace EcommerceCaseStudy.Repos.Interfaces
{
    public interface IOrderRepo:IGenericRepo<Order>
    {
        Task<GetOrderDTO> GetOrderByIdIncludingItems(int id);
        Task<Order> Patch(int id ,string status);

        Task<decimal> TotalRevenue();
    }
}
