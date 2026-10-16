using EcommerceCaseStudy.Models;

namespace EcommerceCaseStudy.Repos.Interfaces
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        Task<List<Product>> Pagnation(int? categoryid, string? sortby, int pagenumber=1, int pagesize=5);
        Task<List<Product>> SearchByName(string name);
       

        Task<Product> SecondMostExpensiveProductExcludingCategory(int categoryid);
    }
}
