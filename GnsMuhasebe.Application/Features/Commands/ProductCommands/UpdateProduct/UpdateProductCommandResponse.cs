using GnsMuhasebe.Application.Common;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Barcode { get; set; } = string.Empty;
    }
}
