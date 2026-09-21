using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int CategoryId {  get; set; }
        public int Stock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string? Barcode { get; set; } = string.Empty;
    }
}
