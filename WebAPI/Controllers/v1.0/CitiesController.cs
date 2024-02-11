using Application.Features.City.Commands.Create;
using Application.Features.City.Commands.Delete;
using Application.Features.City.Commands.Update;
using Application.Features.City.Queries.Get;
using Application.Features.City.Queries.GetById;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1._0
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCityQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _mediator.Send(new GetCityByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCityCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCityCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCityCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
