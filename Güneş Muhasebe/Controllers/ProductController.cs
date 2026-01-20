using GnsMuhasebe.Application.Features.Commands.CreateProduct;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.Infrastucture.Repositrories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Güneş_Muhasebe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Product> _productRepository;
        public ProductController(IMediator mediator, IGenericRepository<Product> productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.Status , response);
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
