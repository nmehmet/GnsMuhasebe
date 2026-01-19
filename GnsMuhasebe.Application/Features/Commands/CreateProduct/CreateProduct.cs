using AutoMapper;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using MediatR;

namespace GnsMuhasebe.Application.Features.Commands.CreateProduct
{
    public class CreateProduct : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
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
            
           if(request != null)
            {
                Product product = mapper.Map<Product>(request);
                int result = await productRepository.AddAsync(product);
            }
            else
            {
                response.SetStatus(1001);
            }


                return null; 
        }
    }
}
