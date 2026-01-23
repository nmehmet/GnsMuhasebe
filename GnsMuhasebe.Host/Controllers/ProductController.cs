using GnsMuhasebe.Application.Features.Commands.CreateProduct;
using GnsMuhasebe.Application.Features.Commands.SellProduct;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
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
            CreateProductResponse response = await _mediator.Send(request);
            return StatusCode(response.Status , response);
        }
        [HttpPost("SellProduct/{Id:int}/{Quantity:int}")]
        public async Task<IActionResult> SellProduct(SellProductRequest request, int Id, int Quantity)
        {
            request.ProductId = Id;
            request.ProductQuantity = Quantity;
            SellProductResponse response = await _mediator.Send(request);
            return StatusCode(response.Status,response);
        }
        [HttpGet("GetProductById/{Id:int}")]
        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetByIdAsync(Id) ?? new Product();
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
