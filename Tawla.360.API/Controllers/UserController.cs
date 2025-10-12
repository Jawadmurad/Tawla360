using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.UsersUseCases.Commands;
using Tawla._360.Application.UsersUseCases.Dtos;

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
    }
}
