using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Queries.Genres.GetAllGenres;
using Tabloid.Application.Queries.Genres.GetAllMetalGenres;
using Tabloid.Application.Queries.Genres.GetEveryOtherGenre;
using Tabloid.Application.Queries.Genres.GetAllRockGenres;
using Tabloid.Application.Queries.Genres.GetGenreByName;
using Tabloid.Application.Queries.Genres.GetAllElectroGenres;
using Tabloid.Helpers;
using Tabloid.Requests.GenreRequest;
using Tabloid.Application.Commands.Genres.AddGenre;
using Tabloid.Application.Commands.Genres.UpdateGenre;
using Tabloid.Application.Commands.Genres.DeleteGenre;

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

        [HttpPost("add")]
        public async Task<IActionResult> AddGenre([FromBody] GenreRequest request)
        {
            var response = await _mediator.Send(new AddGenreCommand(request.Genre));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreRequest request)
        {
            var response = await _mediator.Send(new UpdateGenreCommand(request.Genre));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteGenre(Guid id)
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

        [HttpGet("{name}")]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var response = await _mediator.Send(new GetGenreByNameQuery(name));
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
