using MediatR;
using Microsoft.AspNetCore.Mvc;
using Photoexpress.Application.Features.Events.Commands.Create;
using Photoexpress.Application.Features.Events.Queries.All;
using Photoexpress.Application.Features.Events.Queries.ById;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult> Save(EventVm eventInstance)
        {
            Response<EventVm> response = new Response<EventVm>();
            response.Result = await _mediator.Send(new CreateEventCommand(eventInstance));

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll/{orderBy}/{ascendent}/{pageIndex}/{pageSize}")]
        public async Task<ActionResult> GetAll(string orderBy, bool ascendent, int? pageIndex, int? pageSize)
        {
            var query = new GetEventListQuery(orderBy, ascendent, pageIndex, pageSize);

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var query = new GetEventByIdQuery(Id);

            return Ok(await _mediator.Send(query));
        }
    }
}
