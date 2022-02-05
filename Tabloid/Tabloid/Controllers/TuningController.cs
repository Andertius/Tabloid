using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands;
using Tabloid.Application.Commands.Tunings.AddTuning;
using Tabloid.Application.Commands.Tunings.DeleteTuning;
using Tabloid.Application.Commands.Tunings.UpdateTuning;
using Tabloid.Application.Queries.Tunings.GetAllTunings;
using Tabloid.Application.Queries.Tunings.GetTuningByName;
using Tabloid.Application.Queries.Tunings.GetTuningsByStringNumber;

using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Enums;
using Tabloid.Domain.Responses.HttpResponses;
using Tabloid.Helpers;
using Tabloid.Requests.TuningRequests;

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

        [HttpPost("tunings/add")]
        public async Task<IActionResult> AddTuning([FromBody] TuningRequest request)
        {
            var response = await _mediator.Send(new AddTuningCommand(request.Tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPost("tunings/update")]
        public async Task<IActionResult> UpdateTuning([FromBody] TuningRequest request)
        {
            var response = await _mediator.Send(new UpdateTuningCommand(request.Tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPost("tunings/delete")]
        public async Task<IActionResult> DeleteTuning([FromBody] TuningRequest request)
        {
            var response = await _mediator.Send(new DeleteTuningCommand(request.Tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("tunings")]
        public async Task<IActionResult> GetAllTunings()
        {
            var response = await _mediator.Send(new GetAllTuningsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("tunings/name/{name}")]
        public async Task<IActionResult> GetTuningByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetTuningByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("tunings/strings/{stringNumber}")]
        public async Task<IActionResult> GetTuningsByStringNumber([FromRoute] int stringNumber)
        {
            var response = await _mediator.Send(new GetTuningsByStringNumberQuery(stringNumber));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
