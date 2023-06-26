using MediatR;
using Microsoft.AspNetCore.Mvc;
using Photoexpress.Application.Features.Parameters.Queries.All;
using Photoexpress.Application.Features.Parameters.Queries.ById;

namespace Photoexpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParameterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetParameterListQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(Guid? id)
        {
            var query = new GetParamaterByIdQuery(id);

            return Ok(await _mediator.Send(query));
        }
    }
}
