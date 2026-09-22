using MediatR;

namespace GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
