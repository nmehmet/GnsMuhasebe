using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommand : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommand(IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new BusinessException(BusinessErrorCode.InvalidRequest);

            Product product = await _productRepository.GetByIdAsync(request.Id) ?? throw new BusinessException(BusinessErrorCode.ProductCouldNotFound);

            Category category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new BusinessException(BusinessErrorCode.CategoryCouldNotFound);

            product.UpdateProduct(request.Name, request.CategoryId, request.Description, request.PurchasePrice, request.SalePrice, request.Barcode);
            _productRepository.Update(product);

            int result = await _productRepository.SaveChangesAsync(cancellationToken);
            if (result == 0) throw new BusinessException(BusinessErrorCode.ProductCouldNotUpdated);

            UpdateProductCommandResponse response = _mapper.Map<UpdateProductCommandResponse>(product);

            response.SetStatus(200);
            return response;
        }
    }
}
