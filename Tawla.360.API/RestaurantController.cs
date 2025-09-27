using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;
using Tawla._360.Application.RestaurantUseCases.Queries;

namespace Tawla._360.API;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEmailSender _emailSender;
    public RestaurantController(IMediator mediator, IEmailSender emailSender)
    {
        _emailSender = emailSender;
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateRestaurantWithAdmin createRestaurantWith)
    {
        await _mediator.Publish(new CreateRestaurantCommand(createRestaurantWith));
        return Ok();
    }
    [HttpGet("Lite")]

    public async Task<IActionResult> Lite()
    {
        await _emailSender.SendEmailAsync("testiemailsender@yopmail.com", "test done", "helllo");
        return Ok(await _mediator.Send(new GetAllRestaurantLiteQuery()));
    }
}
