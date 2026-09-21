using MediatR;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Exceptions;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductByBarcode
{
    internal class GetProductByBarcodeQuery : IRequestHandler<GetProductByBarcodeQueryRequest, GetProductByBarcodeQueryResponse>
    {
        private readonly IGenericRepository<domain.Entities.Product> _productRepository;
        public GetProductByBarcodeQuery(IGenericRepository<domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetProductByBarcodeQueryResponse> Handle(GetProductByBarcodeQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Barcode))
            {
                throw new BusinessException(domain.Enums.BusinessErrorCode.RequestIsEmpty);
            }

            Product product = await _productRepository.GetFirstOrDefaultAsync(p => p.Barcode == request.Barcode) ?? throw new BusinessException(domain.Enums.BusinessErrorCode.InvalidBarcodeProduct);
           
            GetProductByBarcodeQueryResponse response = new GetProductByBarcodeQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                SalePrice = product.SalePrice,
                Stock = product.Stock,
                Barcode = request.Barcode
            };

            response.SetStatus(200);

            return response;
        }
    }
}
