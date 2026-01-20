using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateProduct
{
    public class CreateProduct : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private enum ErrorCodes : int
        {
            Succes = 200,
            NullRequest = 1001,
            UndefinedName = 1002,
            UndefinedStock = 1003,
            UndefinedSalePrice = 1004,
            CouldNotAddedToTable = 1005
        }
        private readonly IGenericRepository<Product> productRepository;
        private readonly IMapper mapper;

        public CreateProduct(IGenericRepository<Product> _repository, IMapper _mapper)
        {
            mapper = _mapper;
            productRepository = _repository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            CreateProductResponse response = new CreateProductResponse();

            if (request == null) response.SetStatus((int)ErrorCodes.NullRequest);
            else if (String.IsNullOrEmpty(request.Name)) response.SetStatus((int)ErrorCodes.UndefinedName);
            else if (request.Stock <= 0) response.SetStatus((int)ErrorCodes.UndefinedStock);
            else if (request.SalePrice <= 0) response.SetStatus((int)ErrorCodes.UndefinedSalePrice);
            else
            {
                Product product = mapper.Map<Product>(request);
                try
                {
                    await productRepository.AddAsync(product);
                    int result = productRepository.SaveChangesAsync(cancellationToken).Result;
                    if (result > 0)
                    {
                        response.SetStatus(200);
                        response.AddedProduct = product;
                    }
                    else response.SetStatus((int)ErrorCodes.CouldNotAddedToTable);
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
