using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;
using Tawla._360.Application.RestaurantUseCases.Queries;

namespace Tawla._360.API;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;
    public RestaurantController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateRestaurantWithAdmin createRestaurantWith)
    {
        await _mediator.Publish(new CreateRestaurantCommand(createRestaurantWith));
        return Ok();
    }
    [HttpPost("GetPaged")]
    public async Task<IActionResult> GetPaged(QueryRequestDto query)
    {
        return Ok(await _mediator.Send(new GetRestaurantPagedQuery(query)));
    }
    [HttpGet("Lite")]
    public async Task<IActionResult> Lite()
    {
        return Ok(await _mediator.Send(new GetAllRestaurantLiteQuery()));
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Publish(new DeleteRestaurantCommand(id));
        return Ok();
    }
}
