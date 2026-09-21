using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<CreateCategoryResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description {  get; set; }
    }
}
