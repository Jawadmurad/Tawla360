using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.BranchUseCases.Commands;
using Tawla._360.Application.BranchUseCases.Dtos;
using Tawla._360.Application.BranchUseCases.Queries;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchDto createBranch)
        {
            await _mediator.Publish(new CreateBranchCommand(createBranch));
            return Ok();
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(QueryRequestDto query)
        {
            return Ok(await _mediator.Send(new GetBranchPagedQuery(query)));
        }
        [HttpGet("Lite")]
        public async Task<IActionResult> Lite()
        {
            return Ok(await _mediator.Send(new GetAllBranchLiteQuery()));
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Publish(new DeleteBranchCommand(id));
            return Ok();
        }
    }
}
