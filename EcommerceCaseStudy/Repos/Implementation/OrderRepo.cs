using EcommerceCaseStudy.Data;
using EcommerceCaseStudy.DTO.Order;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCaseStudy.Repos.Implementation
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GetOrderDTO> GetOrderByIdIncludingItems(int id)
        {
            var c=await _context.Orders.Include(c=>c.orderItems).FirstOrDefaultAsync(c=>c.Id==id);

            var dto = new GetOrderDTO
            {

            };
            return dto;
        }

        public async Task<Order> Patch(int id, string status)
        {
            var order=await _context.Orders.FirstOrDefaultAsync(c=>c.Id==id);
            if(order == null) { return null; }

            order.Status = status;
            _context.SaveChanges();
            return order;
        }

        public async Task<decimal> TotalRevenue()
        {
            return await _context.Orders.Where(c => c.Status == "Completed").SumAsync(c => c.TatalAmout);
        }
    }
}
