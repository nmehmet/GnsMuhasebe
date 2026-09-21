using MediatR;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductByBarcode
{
    public class GetProductByBarcodeQueryRequest : IRequest<GetProductByBarcodeQueryResponse>
    {
        public required string Barcode { get; set; }
    }
}
