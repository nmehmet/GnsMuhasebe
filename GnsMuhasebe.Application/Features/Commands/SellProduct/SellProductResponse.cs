using GnsMuhasebe.Application.Common;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Commands.SellProduct
{
    public class SellProductResponse : BaseResponse
    {
        public Product? UpdatedProduct { get; set; }
    }
}
