using AutoMapper;
using GnsMuhasebe.Application.Features.Commands.CreateProduct;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,CreateProductRequest>().ReverseMap();
        }
    }
}
