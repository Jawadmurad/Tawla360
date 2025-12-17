using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.ItemUseCases.Command;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Application.ItemUseCases.Query;

namespace Tawla._360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateItemWithImageDto createItemDto)
        {
            await _mediator.Publish(new CreateItemCommand(createItemDto));
            return Ok();
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(QueryRequestDto query)
        { 
            return Ok(await _mediator.Send(new GetItemPagedQuery(query)));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetItemByIdQuery(id)));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateItemWithImageDto updateItem)
        {
            await _mediator.Publish(new UpdateItemCommand(updateItem));
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteItemCommand(id));
            return Ok();
        }
    }
}
