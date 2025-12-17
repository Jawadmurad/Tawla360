using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.CategoryUseCases.Command;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.CategoryUseCases.Queries;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            await _mediator.Publish(new CreateCategoryCommand(createCategory));
            return Ok();
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetAllCategoryLiteQuery()));
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetCategoryPagedQuery(query)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteCategoryCommand(id));
            return Ok();
        }
    }
}
