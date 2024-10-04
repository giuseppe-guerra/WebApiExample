using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Entities;

namespace WebApplication1.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}
