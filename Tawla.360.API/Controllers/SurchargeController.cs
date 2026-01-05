using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.SurchargeUseCase.Command;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Application.SurchargeUseCase.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SurchargeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurchargeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSurchargeDto surchargeDto)
        {
            await _mediator.Publish(new CreateSurchargeCommand(surchargeDto));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSurchargeDto surchargeDto)
        {
            await _mediator.Publish(new UpdateSurchargeCommand(surchargeDto));
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteSurchargeCommand(id));
            return Ok();
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetAllLite()
        {
            return Ok(await _mediator.Send(new GetAllSurchargesLiteQuery()));
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged([FromBody] QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetSurchargePagedQuery(query)));
        }
    }
}
