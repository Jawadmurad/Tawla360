using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.TaxesCases.Commands;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Application.TaxesCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaxController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaxController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaxDto createTax)
        {
            await _mediator.Publish(new CreateTaxCommand(createTax));
            return Ok();
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetAllLite()
        {
            return Ok(await _mediator.Send(new GetAllTaxesLiteQuery()));
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage([FromBody] QueryRequestDto query)
        {
            return Ok(_mediator.Send(new GetTaxPagedQuery(query)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTaxCommand(id));
            return Ok();
        }
    }

}
