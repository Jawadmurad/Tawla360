using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.ModifierUseCases.Command;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Application.ModifierUseCases.Query;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModifierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModifierController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateModifierDto createModifier)
        {
            await _mediator.Publish(new CreateModifierCommand(createModifier));
            return Ok();
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetModifierPagedQuery(query)));
        }
        [HttpDelete("{id}:guid")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteModifierCommand(id));
            return Ok();
        }
        [HttpGet("lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetModifierLiteQuery()));
        }
    }
}
