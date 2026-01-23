using GnsMuhasebe.Application.Features.Commands.CreateCategory;
using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Güneş_Muhasebe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Category> _categoryRepository;
        public CategoryController(IMediator mediator, IGenericRepository<Category> categoryRepository)
        {
            _mediator = mediator;
            _categoryRepository = categoryRepository;
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateProduct(CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(response.Status, response);
        }
        [HttpGet("GetAllCategory")]
        public async Task<List<Category>> GetAllProducts()
        {
            return await _categoryRepository.GetAllAsync();
        }
        [HttpGet("GetCategoryById{Id:int}")]
        public async Task<Category> GetCategoryById(int Id)
        {
            return await _categoryRepository.GetByIdAsync(Id) ?? new Category();
        }
    }
}
