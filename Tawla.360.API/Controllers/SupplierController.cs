using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.SupplierUseCases.Commands;
using Tawla._360.Application.SupplierUseCases.Dto;
using Tawla._360.Application.SupplierUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierDto createSupplier)
        {
            await _mediator.Publish(new CreateSupplierCommand(createSupplier));
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteSupplierCommand(id));
            return Ok();
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetSupplierPagedQuery(query)));
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> GetLite()
        {
            return Ok(await _mediator.Send(new GetAllSupplierLite()));
        }
    }
}
