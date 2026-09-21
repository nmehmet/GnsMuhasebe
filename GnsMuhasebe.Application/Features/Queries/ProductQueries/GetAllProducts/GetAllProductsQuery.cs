using AutoMapper;
using GnsMuhasebe.Application.DTOs.Products;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQuery : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQuery(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request ,CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            var productsDtos = _mapper.Map<List<GetAllProductsDTO>>(products);

            if(productsDtos == null || !productsDtos.Any())
            {
                throw new BusinessException(BusinessErrorCode.ProductCouldNotFound);
            }

            GetAllProductsQueryResponse response = new GetAllProductsQueryResponse();
            response.SetStatus(200);

            response.Products = productsDtos;
            return response;
        }
    }
}
