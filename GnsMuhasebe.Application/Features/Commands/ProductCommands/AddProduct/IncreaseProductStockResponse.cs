using GnsMuhasebe.Application.Common;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.AddProduct
{
    public class IncreaseProductStockResponse : BaseResponse
    {
         public Product? UpdatedProduct { get; set; }
    }
}
