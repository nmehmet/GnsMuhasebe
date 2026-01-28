using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Exceptions;
using GnsMuhasebe.domain.Enums;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CreateProductCommand(IGenericRepository<Product> _productRepository,IGenericRepository<Category> _categoryRepository, IMapper _mapper)
        {    
            mapper = _mapper;
            productRepository = _productRepository;
            categoryRepository = _categoryRepository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            CreateProductResponse response = new CreateProductResponse();

            if (request == null) throw new BusinessException(BusinessErrorCode.RequestIsEmpty);
            if (await categoryRepository.GetByIdAsync(request.CategoryId) == null) throw new BusinessException(BusinessErrorCode.CategoryCouldNotFound);

            Product product = new Product(request.Name, request.CategoryId, request.Description ?? String.Empty, request.Stock, request.PurchasePrice, request.SalePrice);
            
            await productRepository.AddAsync(product);
            int result = await productRepository.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                response.SetStatus(200);
                response.AddedProduct = product;
            }
            else throw new BusinessException(BusinessErrorCode.ProductCouldNotBeAdded);

            return response; 
        }
    }
}
