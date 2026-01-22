using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {
        public string Name { get; set; } = String.Empty;
        public string? Description {  get; set; }
    }
}
