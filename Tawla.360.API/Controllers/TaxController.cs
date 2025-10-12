using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Tawla._360.Application.TaxesCases.Commands;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Application.TaxesUseCases;

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
    }
}
