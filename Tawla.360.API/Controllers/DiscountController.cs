using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.DiscountUseCases.Command;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Application.DiscountUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDto createDiscount)
        {
            await _mediator.Publish(new CreateDiscountCommand(createDiscount));
            return Ok();
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetAllDiscountLiteQuery()));
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteDiscountCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountDto updateDiscountDto)
        {
            await _mediator.Publish(new UpdateDiscountCommand(updateDiscountDto));
            return Ok();
        }
    }
}
