using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Queries.Genres.GetAllGenres;
using Tabloid.Application.Queries.Genres.GetAllMetalGenres;
using Tabloid.Application.Queries.Genres.GetEveryOtherGenre;
using Tabloid.Application.Queries.Genres.GetAllRockGenres;
using Tabloid.Application.Queries.Genres.GetGenreByName;
using Tabloid.Application.Queries.Genres.GetAllElectroGenres;

namespace Tabloid.Controllers
{
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var response = await _mediator.Send(new GetAllGenresQuery());
            return Ok(response);
        }

        [HttpGet("genres/{name}")]
        public async Task<IActionResult> GetGenreByName(string name)
        {
            var response = await _mediator.Send(new GetGenreByNameQuery(name));
            return Ok(response);
        }

        [HttpGet("genres/rock")]
        public async Task<IActionResult> GetAllRockGenres()
        {
            var response = await _mediator.Send(new GetAllRockGenresQuery());
            return Ok(response);
        }

        [HttpGet("genres/metal")]
        public async Task<IActionResult> GetAllMetalGenres()
        {
            var response = await _mediator.Send(new GetAllMetalGenresQuery());
            return Ok(response);
        }

        [HttpGet("genres/electro")]
        public async Task<IActionResult> GetAllElectroGenres()
        {
            var response = await _mediator.Send(new GetAllElectroGenresQuery());
            return Ok(response);
        }

        [HttpGet("genres/every-other")]
        public async Task<IActionResult> GetEveryOtherGenre()
        {
            var response = await _mediator.Send(new GetEveryOtherGenreQuery());
            return Ok(response);
        }
    }
}
