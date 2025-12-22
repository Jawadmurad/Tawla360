using System.Security.Permissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.AuthUseCases.Commands;
using Tawla._360.Application.AuthUseCases.Dtos;
using Tawla._360.Application.AuthUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            return Ok(await _mediator.Send(new LoginQuery(loginRequest)));
        }
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromForm] string refreshToken)
        {
            return Ok(await _mediator.Send(new RefreshTokenQuery(refreshToken)));
        }
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] string email, [FromForm] string token, [FromForm] string password)
        {
            await _mediator.Publish(new ResetPasswordCommand(email, token, password));
            return Ok();
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            await _mediator.Publish(new ForgetPasswordCommand(email));
            return Ok();
        }
    }
}
