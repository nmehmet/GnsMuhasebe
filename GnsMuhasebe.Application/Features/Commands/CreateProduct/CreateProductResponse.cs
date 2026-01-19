using GnsMuhasebe.Application.Common;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Commands.CreateProduct
{
    public class CreateProductResponse : BaseResponse
    {
        public Product? AddedProduct { get; set; }
    }
}
