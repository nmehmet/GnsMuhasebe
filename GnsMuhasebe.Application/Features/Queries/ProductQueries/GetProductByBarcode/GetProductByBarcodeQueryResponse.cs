using GnsMuhasebe.Application.Common;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductByBarcode
{
    public class GetProductByBarcodeQueryResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; } = string.Empty;
    }
}
