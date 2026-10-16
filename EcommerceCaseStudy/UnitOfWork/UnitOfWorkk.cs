using EcommerceCaseStudy.Data;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.Repos.Interfaces;

namespace EcommerceCaseStudy.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        public IAuthRepo AuthRepo { get; }

        public IGenericRepo<Category> Category {  get; }

        public IProductRepo Product {  get; }

        public IOrderRepo Order {  get; }

        public IGenericRepo<OrderItem> OrderItem {  get; }

        private readonly AppDbContext _context;
        public UnitOfWorkk(IAuthRepo authRepo, AppDbContext context, IGenericRepo<Category> category, IProductRepo product,IOrderRepo order,IGenericRepo<OrderItem> orderitem)
        {
            AuthRepo = authRepo;
            _context = context;
            Category = category;
            Product = product;
            Order = order;
            OrderItem = orderitem;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
