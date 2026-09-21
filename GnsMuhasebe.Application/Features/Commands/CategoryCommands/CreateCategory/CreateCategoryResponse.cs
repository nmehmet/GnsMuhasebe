using GnsMuhasebe.Application.Common;
using GnsMuhasebe.domain.Entities;

namespace GnsMuhasebe.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryResponse : BaseResponse
    {
        public Category? AddedCategory { get; set; }
    }
}
