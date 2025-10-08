using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RoleUseCases.Command;
using Tawla._360.Application.RoleUseCases.Dto;
using Tawla._360.Application.RoleUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Lite")]
        public async Task<ActionResult<IReadOnlyList<LiteRoleDto>>> GetLite()
        {
            return Ok(await _mediator.Send(new GetAllRoleLiteQuery()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto createRole, [FromServices] IHttpContextAccessorService httpContextAccessorService)
        {
            var x = httpContextAccessorService.GetRestaurantId();
            await _mediator.Publish(new CreateRoleCommand(createRole));
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteRoleCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleDto updateRole)
        {
            await _mediator.Publish(new UpdateRoleCommand(updateRole));
            return Ok();
        }



    }
}
