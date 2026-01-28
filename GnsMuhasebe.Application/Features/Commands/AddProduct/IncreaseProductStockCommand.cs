using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.AddProduct
{
    public class IncreaseProductStockCommand : IRequestHandler<IncreaseProductStockRequest, IncreaseProductStockResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public IncreaseProductStockCommand(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IncreaseProductStockResponse> Handle(IncreaseProductStockRequest request, CancellationToken canceliationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.ProductId);
            IncreaseProductStockResponse response = new IncreaseProductStockResponse();

            if (product == null) throw new BusinessException(BusinessErrorCode.ProductCouldNotFound);
            product.IncreaseStock(request.Quantity);

            _productRepository.Update(product);
            int result = await _productRepository.SaveChangesAsync(canceliationToken);
            if (result == 0) throw new BusinessException(BusinessErrorCode.ProductCouldNotUpdated);
            
            response.SetStatus(200);
            response.UpdatedProduct = product;

            return response;

        }

    }
}
