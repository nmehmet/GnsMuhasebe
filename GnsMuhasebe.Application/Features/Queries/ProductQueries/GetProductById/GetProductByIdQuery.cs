using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQuery : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQuery(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id <= 0) throw new BusinessException(BusinessErrorCode.InvalidRequest);

            Product product = await _productRepository.GetByIdAsync(request.Id) ?? throw new BusinessException(BusinessErrorCode.ProductCouldNotFound);

            GetProductByIdQueryResponse response = new GetProductByIdQueryResponse();

            _mapper.Map(product, response);
            response.SetStatus(200);
            return response;
        }
    }
}
