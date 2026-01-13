using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.TableUseCases.Commands;
using Tawla._360.Application.TableUseCases.Dtos;
using Tawla._360.Application.TableUseCases.Queries;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTableDto createTable)
        {
            await _mediator.Publish(new CreateTableCommand(createTable));
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllTablesQuery()));
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteTableCommand(id));
            return Ok();
        }
    }
}
