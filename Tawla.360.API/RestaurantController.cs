using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Application.RestaurantUseCases.Queries;

namespace Tawla._360.API
{
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
        public async Task<IActionResult> Create(CreateRestaurantDto createRestaurant)
        {
            await _mediator.Publish(new CreateRestaurantCommand(createRestaurant));
            return Ok();
        }
        [HttpGet("Lite")]
        
        public async Task<IActionResult> Lite()
        {
            return Ok(await _mediator.Send(new GetAllRestaurantLiteQuery()));
        }
    }
}
