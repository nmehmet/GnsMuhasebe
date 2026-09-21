using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.AddProduct
{
    public class IncreaseProductStockRequest : IRequest<IncreaseProductStockResponse>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
