using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        private enum ErrorCodes : int
        {
            Success = 200,
            InvalidName = 1011,
            CategoryCouldNotAdded = 1012
        }
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommand(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            CreateCategoryResponse response = new CreateCategoryResponse();
            if (String.IsNullOrEmpty(request.Name)) response.SetStatus((int)ErrorCodes.InvalidName);
            else
            {
                Category category = _mapper.Map<Category>(request);
                try
                {
                    await _categoryRepository.AddAsync(category);
                    int result = _categoryRepository.SaveChangesAsync(cancellationToken).Result;
                    if (result > 0)
                    {
                        response.SetStatus((int)ErrorCodes.Success);
                        response.AddedCategory = category;
                    }
                    else response.SetStatus((int)ErrorCodes.CategoryCouldNotAdded);
                }
                catch (Exception ex) 
                {
                    response.SetStatus(ex.HResult);
                    if (!String.IsNullOrEmpty(ex.Message)) response.Message = ex.Message;
                }
            }

            return response;
        }
    }
}
