using GnsMuhasebe.Application.Features.Commands.ProductCommands.CreateProduct;
using GnsMuhasebe.Application.Features.Commands.ProductCommands.SellProduct;
using GnsMuhasebe.Application.Features.Queries.ProductQueries.GetAllProducts;
using GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductByBarcode;
using GnsMuhasebe.Application.Features.Queries.ProductQueries.GetProductById;
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
            return StatusCode(response.Status, response);
        }
        [HttpPost("SellProduct/{Id:int}/{Quantity:int}")]
        public async Task<IActionResult> SellProduct(SellProductRequest request, int Id, int Quantity)
        {
            request.ProductId = Id;
            request.ProductQuantity = Quantity;
            SellProductResponse response = await _mediator.Send(request);
            return StatusCode(response.Status, response);
        }
        [HttpGet("GetProductByIdDebug/{Id:int}")]
        public async Task<Product> GetProductByIdDebug(int Id)
        {
            return await _productRepository.GetByIdAsync(Id) ?? new Product();
        }
        [HttpGet("GetProductById/{Id:int}")]
        public async Task<GetProductByIdQueryResponse> GetProductById(int Id)
        {
            GetProductByIdQueryRequest request = new GetProductByIdQueryRequest
            {
                Id = Id
            };
            GetProductByIdQueryResponse response = await _mediator.Send(request);
            return response;
        }
        [HttpGet("GetPrductByBarcode/{Barcode}")]
        public async Task<IActionResult> GetProductByBarcode(string Barcode)
        {
            GetProductByBarcodeQueryRequest request = new GetProductByBarcodeQueryRequest
            {
                Barcode = Barcode
            };
            GetProductByBarcodeQueryResponse response = await _mediator.Send(request);
            return StatusCode(response.Status, response);
        }
        [HttpGet("GetAllProductsDebug")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsQuery()
        {
            var request = new GetAllProductsQueryRequest();
            var response = await _mediator.Send(request);
            return StatusCode(response.Status, response);
        }
    }
}
