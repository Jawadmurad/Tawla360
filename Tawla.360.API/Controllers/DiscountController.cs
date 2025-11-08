using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.DiscountUseCases.Command;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Application.DiscountUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetDiscountPagedQuery(query)));
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
    }
}
