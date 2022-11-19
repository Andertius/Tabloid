using System;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Genres.Commands.AddGenre;
using Tabloid.Application.CQRS.Genres.Commands.DeleteGenre;
using Tabloid.Application.CQRS.Genres.Commands.UpdateGenre;
using Tabloid.Application.CQRS.Genres.Queries.FindGenreById;
using Tabloid.Application.CQRS.Genres.Queries.GetAllElectroGenres;
using Tabloid.Application.CQRS.Genres.Queries.GetAllGenres;
using Tabloid.Application.CQRS.Genres.Queries.GetAllJustNames;
using Tabloid.Application.CQRS.Genres.Queries.GetAllMetalGenres;
using Tabloid.Application.CQRS.Genres.Queries.GetAllRockGenres;
using Tabloid.Application.CQRS.Genres.Queries.GetEveryOtherGenre;
using Tabloid.Application.CQRS.Genres.Queries.GetGenreByName;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] GenreDto genre)
        {
            var response = await _mediator.Send(new AddGenreCommand(genre));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreDto genre)
        {
            var response = await _mediator.Send(new UpdateGenreCommand(genre));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteGenreCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var response = await _mediator.Send(new GetAllGenresQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindGenreById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new FindGenreByIdQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetGenreByName([FromQuery] string name)
        {
            var response = await _mediator.Send(new GetGenreByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("just-names")]
        public async Task<IActionResult> GetAllJustNames()
        {
            var response = await _mediator.Send(new GetAllJustNamesQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("rock")]
        public async Task<IActionResult> GetAllRockGenres()
        {
            var response = await _mediator.Send(new GetAllRockGenresQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("metal")]
        public async Task<IActionResult> GetAllMetalGenres()
        {
            var response = await _mediator.Send(new GetAllMetalGenresQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("electro")]
        public async Task<IActionResult> GetAllElectroGenres()
        {
            var response = await _mediator.Send(new GetAllElectroGenresQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("every-other")]
        public async Task<IActionResult> GetEveryOtherGenre()
        {
            var response = await _mediator.Send(new GetEveryOtherGenreQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
