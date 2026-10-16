using AutoMapper;
using EcommerceCaseStudy.DTO.Category;
using EcommerceCaseStudy.DTO.Product;
using EcommerceCaseStudy.Models;

namespace EcommerceCaseStudy.Mapping
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {

            CreateMap<Category, GetCategoryDTO>();
            CreateMap<CreateCategoryDTO, Category>();

            CreateMap<Product, GetProductDTO>();
            CreateMap<CreateProductDTO, Product>();


        }
    }
}
