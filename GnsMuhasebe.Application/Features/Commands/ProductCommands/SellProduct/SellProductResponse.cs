using GnsMuhasebe.Application.Common;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.SellProduct
{
    public class SellProductResponse : BaseResponse
    {
        public Product? UpdatedProduct { get; set; }
    }
}
