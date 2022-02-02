using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Queries.Tunings.GetAllTunings;
using Tabloid.Application.Queries.Tunings.GetTuningByName;
using Tabloid.Application.Queries.Tunings.GetTuningByStringNumber;

namespace Tabloid.Controllers
{
    [ApiController]
    public class TuningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TuningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("tunings")]
        public async Task<IActionResult> GetAllTunings()
        {
            var response = await _mediator.Send(new GetAllTuningsQuery());
            return Ok(response);
        }

        [HttpGet("tunings/name/{name}")]
        public async Task<IActionResult> GetTuningByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetTuningByNameQuery(name));
            return Ok(response);
        }

        [HttpGet("tunings/strings/{stringNumber}")]
        public async Task<IActionResult> GetTuningByStringNumber([FromRoute] int stringNumber)
        {
            var response = await _mediator.Send(new GetTuningByStringNumberQuery(stringNumber));
            return Ok(response);
        }
    }
}
