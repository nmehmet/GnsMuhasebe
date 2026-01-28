using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Exceptions;
using GnsMuhasebe.domain.Enums;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
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

            Category category = new Category(request.Name,request.Description ?? String.Empty);

            await _categoryRepository.AddAsync(category);
            int result = await _categoryRepository.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                response.SetStatus(200);
                response.AddedCategory = category;
            }
            else throw new BusinessException(BusinessErrorCode.CategoryCouldNotAdded);
            

            return response;
        }
    }
}
