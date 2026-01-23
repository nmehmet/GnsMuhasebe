using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
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
            try
            {
                Product? product = await _productRepository.GetByIdAsync(request.ProductId);


                if (product == null) response.SetStatus((int)ErrorCodes.ProductCouldNotFound);
                else if (product.Stock < request.ProductQuantity) response.SetStatus((int)ErrorCodes.NotEnoughProduct);
                else
                {
                    product.DecreaseStock(request.ProductQuantity);
                    _productRepository.Update(product);
                    int result = _productRepository.SaveChangesAsync(cancellationToken).Result;
                    if (result == 0) response.SetStatus((int)ErrorCodes.ProductCouldNotUpdated);
                    else
                    {
                        response.SetStatus((int)ErrorCodes.Success);
                        response.UpdatedProduct = product;
                    }
                }

            }catch (Exception ex)
            {
                response.SetStatus(ex.HResult);
                if (!String.IsNullOrEmpty(ex.Message)) response.Message = ex.Message;
            }

            return response;
        }
    }
}
