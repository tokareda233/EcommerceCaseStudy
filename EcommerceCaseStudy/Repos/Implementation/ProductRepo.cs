using EcommerceCaseStudy.Data;
using EcommerceCaseStudy.Models;
using EcommerceCaseStudy.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EcommerceCaseStudy.Repos.Implementation
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Product>> Pagnation(int? categoryid, string? sortby, int pagenumber=1, int pagesize=5)
        {
            var query =  _context.Products.AsQueryable();
            if(categoryid.HasValue)
            {
                query =  query.Where(x => x.CategoryId == categoryid);
            }

            switch(sortby?.ToLower())
            {
                case "price":
                    query=query.OrderBy(c => c.Price);
                    break;

                case "stockquantity":
                    query = query.OrderBy(p => p.StockQuantity);
                    break;

                case "name":
                    query = query.OrderBy(p => p.Name);
                    break;

                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            var products = await query
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync();
            return products;
            
        }

        public async Task<List<Product>> SearchByName(string name)
        {
            return await _context.Products.Where(x=>x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Product> SecondMostExpensiveProductExcludingCategory(int categoryid)
        {
            return await _context.Products
                .Where(c => c.CategoryId != categoryid)
                 .OrderByDescending(x => x.Price)
                 .Skip(1)
                 .FirstOrDefaultAsync();
        }
    }
}
