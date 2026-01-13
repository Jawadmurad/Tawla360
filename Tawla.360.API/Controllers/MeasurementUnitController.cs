using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.MeasurementUnitUserCases.Commands;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Application.MeasurementUnitUserCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementUnitController : ControllerBase
    {

        private readonly IMediator _mediator;
        public MeasurementUnitController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMeasurementUnitDto dto)
        {
            await _mediator.Publish(new CreateMeasurementUnitCommand(dto));
            return Ok();
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetPagedMeasurementUnitQuery(query)));
        }
        [HttpGet("lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetMeasurementUnitLiteQuery()));
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteMeasurementUnitCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMeasurementUnitDto dto)
        {
            await _mediator.Publish(new UpdateMeasurementUnitCommand(dto));
            return Ok();
        }

    }
}
