﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTuning;
using Tabloid.Application.CQRS.Tunings.Commands.AddTuning;
using Tabloid.Application.CQRS.Tunings.Commands.DeleteTuning;
using Tabloid.Application.CQRS.Tunings.Commands.UpdateTuning;
using Tabloid.Application.CQRS.Tunings.Queries.GetAllTunings;
using Tabloid.Application.CQRS.Tunings.Queries.GetTuningByName;
using Tabloid.Application.CQRS.Tunings.Queries.GetTuningsByStringNumber;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

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

        [HttpPost]
        public async Task<IActionResult> AddTuning([FromBody] GuitarTuningDto tuning)
        {
            var response = await _mediator.Send(new AddTuningCommand(tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTuning([FromBody] GuitarTuningDto tuning)
        {
            var response = await _mediator.Send(new UpdateTuningCommand(tuning));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuning([FromRoute] Guid id)
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

        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetAllSongsByTuning([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetAllSongsByTuningQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
