using AutoMapper;
using GnsMuhasebe.Application.DTOs.Products;
using GnsMuhasebe.Application.Features.Commands.CategoryCommands.CreateCategory;
using GnsMuhasebe.Application.Features.Commands.ProductCommands.CreateProduct;
using GnsMuhasebe.Application.Features.Commands.ProductCommands.UpdateProduct;
using GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductById;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Product Mappings
            CreateMap<Product,CreateProductRequest>().ReverseMap();
            CreateMap<Product, GetAllProductsDTO>().ReverseMap();   
            CreateMap<Product, GetProductByIdQueryResponse>().ReverseMap();
            CreateMap<Product, UpdateProductCommandResponse>().ReverseMap();

            // Category Mappings
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        }
    }
}
