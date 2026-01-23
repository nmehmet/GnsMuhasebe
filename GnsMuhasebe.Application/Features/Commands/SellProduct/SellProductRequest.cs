using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.SellProduct
{
    public class SellProductRequest : IRequest<SellProductResponse>
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
