using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Application.UsersUseCases.Dtos;
using Tawla._360.Application.UsersUseCases.Query;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            await _mediator.Publish(new CreateUserCommand(createUserDto));
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteUserCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto updateUser)
        {
            return Ok();
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged([FromBody] QueryRequestDto queryRequest)
        {
            return Ok(await _mediator.Send(new GetUserPagedQuery(queryRequest)));
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetAllUsersLiteQuery()));
        }
        [HttpPost("AssignUserToBranch")]
        public async Task<IActionResult> AssignUserToBranch([FromForm] Guid userId, [FromForm] Guid branchId)
        {
            await _mediator.Publish(new AssignUserFromBranchCommand(userId, branchId));
            return Ok();
        }
        [HttpPost("UnAssignUserFromBranch")]
        public async Task<IActionResult> UnAssignUserFromBranch([FromForm] Guid userId, [FromForm] Guid branchId)
        {
            await _mediator.Publish(new UnAssignUserFromBranchCommand(userId, branchId));
            return Ok();
        }

    }
}
