using AutoMapper;
using ShopAPI.DTOs.BrandDTOs;
using ShopAPI.DTOs.CategoryDTOs;
using ShopAPI.DTOs.ProductDTOs;
using ShopAPI.DTOs.SubDTOs;
using ShopAPI.Models;

namespace ShopAPI.Helper.Mapper
{
    public class AMapper : Profile
    {
        public AMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<SubCategory, SubDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
        }
    }
}
