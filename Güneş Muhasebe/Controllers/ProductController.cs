using GnsMuhasebe.Application.Features.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Güneş_Muhasebe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
