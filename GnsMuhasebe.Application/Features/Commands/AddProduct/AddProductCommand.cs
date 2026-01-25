using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.AddProduct
{
    public class AddProductCommand : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public AddProductCommand(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken canceliationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.ProductId);
            AddProductResponse response = new AddProductResponse();

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
