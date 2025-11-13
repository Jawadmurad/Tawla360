using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.CategoryUseCases.Command;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategory)
        {
            await _mediator.Send(new CreateCategoryCommand(createCategory));
            return Ok();
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(QueryRequestDto query)
        {
            return Ok();
        }
    }
}
