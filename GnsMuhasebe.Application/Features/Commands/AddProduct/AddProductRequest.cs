using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.AddProduct
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
