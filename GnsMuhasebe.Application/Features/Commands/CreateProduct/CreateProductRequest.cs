using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
    }
}
