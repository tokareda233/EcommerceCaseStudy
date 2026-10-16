using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.Repos.Interfaces;

namespace EcommerceCaseStudy.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthRepo AuthRepo { get; }
        IGenericRepo<Category> Category {  get; }
        IProductRepo Product { get; }
        IOrderRepo Order { get; }
        IGenericRepo<OrderItem> OrderItem { get; }
        void Save();
    }
}
