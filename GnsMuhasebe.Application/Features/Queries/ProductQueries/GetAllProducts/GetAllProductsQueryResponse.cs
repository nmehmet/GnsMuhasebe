using GnsMuhasebe.Application.Common;
using GnsMuhasebe.Application.DTOs.Products;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryResponse : BaseResponse
    {
        public List<GetAllProductsDTO> Products { get; set; } = new();
    }
}
