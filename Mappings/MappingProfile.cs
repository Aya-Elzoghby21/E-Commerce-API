using AutoMapper;
using E_commerce.DTOs.ProductDTOs;
using E_commerce.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>()
    .ForMember(dest => dest.Images, opt => opt.Ignore());

          
        }
    }
   
}
