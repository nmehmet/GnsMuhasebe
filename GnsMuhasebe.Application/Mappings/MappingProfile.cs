using AutoMapper;
using GnsMuhasebe.Application.Features.Commands.CategoryCommands.CreateCategory;
using GnsMuhasebe.Application.Features.Commands.ProductCommands.CreateProduct;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,CreateProductRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        }
    }
}
