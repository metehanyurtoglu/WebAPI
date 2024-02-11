using Application.Features.Country.Commands.Create;
using Application.Features.Country.Commands.Delete;
using Application.Features.Country.Commands.Update;
using Application.Features.Country.Queries.Get;
using Application.Features.Country.Queries.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1._0
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCountryQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _mediator.Send(new GetCountryByIdQuery { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCountryCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCountryCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
