using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands.Tunings.AddTuning;
using Tabloid.Application.Commands.Tunings.DeleteTuning;
using Tabloid.Application.Commands.Tunings.UpdateTuning;
using Tabloid.Application.Queries.Tunings.GetAllTunings;
using Tabloid.Application.Queries.Tunings.GetTuningByName;
using Tabloid.Application.Queries.Tunings.GetTuningsByStringNumber;

using Tabloid.Helpers;
using Tabloid.Requests.TuningRequests;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/tunings")]
    public class TuningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TuningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTuning([FromBody] TuningRequest request)
        {
            var response = await _mediator.Send(new AddTuningCommand(request.Tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTuning([FromBody] TuningRequest request)
        {
            var response = await _mediator.Send(new UpdateTuningCommand(request.Tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTuning(Guid id)
        {
            var response = await _mediator.Send(new DeleteTuningCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTunings()
        {
            var response = await _mediator.Send(new GetAllTuningsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTuningByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetTuningByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("strings/{stringNumber}")]
        public async Task<IActionResult> GetTuningsByStringNumber([FromRoute] int stringNumber)
        {
            var response = await _mediator.Send(new GetTuningsByStringNumberQuery(stringNumber));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
