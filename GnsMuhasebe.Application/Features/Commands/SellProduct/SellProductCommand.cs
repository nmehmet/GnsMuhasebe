using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.SellProduct
{
    public class SellProductCommand : IRequestHandler<SellProductRequest, SellProductResponse>
    {
        private enum ErrorCodes : int 
        {
            Success = 200,
            ProductCouldNotFound = 1007,
            NotEnoughProduct = 1008,
            ProductCouldNotUpdated = 1009

        }
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public SellProductCommand(IGenericRepository<Product> productRepoitory, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepoitory;
        }
        public async Task<SellProductResponse> Handle(SellProductRequest request, CancellationToken cancellationToken)
        {
            SellProductResponse response = new SellProductResponse();
            
            
            Product? product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null) throw new BusinessException(BusinessErrorCode.ProductCouldNotFound);
            
            product.DecreaseStock(request.ProductQuantity);
            _productRepository.Update(product);
            int result = _productRepository.SaveChangesAsync(cancellationToken).Result;
            if (result == 0) throw new BusinessException(BusinessErrorCode.ProductCouldNotUpdated);
            else
            {
                response.SetStatus((int)ErrorCodes.Success);
                response.UpdatedProduct = product;
            }

            return response;
        }
    }
}
