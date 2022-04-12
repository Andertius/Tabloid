using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Artists.Queries.FindArtistBySong;
using Tabloid.Application.CQRS.Songs.Commands.AddSong;
using Tabloid.Application.CQRS.Songs.Commands.DeleteSong;
using Tabloid.Application.CQRS.Songs.Commands.UpdateSong;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongs;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByArtists;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByGenres;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByName;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTabDifficulty;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SongController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSong([FromBody] SongDto song)
        {
            var response = await _mediator.Send(new AddSongCommand(song));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromBody] SongDto song)
        {
            var response = await _mediator.Send(new UpdateSongCommand(song));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteSongCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var response = await _mediator.Send(new GetAllSongsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}/artist")]
        public async Task<IActionResult> FindArtistBySong(Guid id)
        {
            var response = await _mediator.Send(new FindArtistBySongQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllSongsByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetAllSongsByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("songs")]
        public async Task<IActionResult> GetAllSongsByArtist([FromQuery] ICollection<Guid> ids)
        {
            var response = await _mediator.Send(new GetAllSongsByArtistsQuery(ids));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetAllSongsByGenres([FromQuery] ICollection<Guid> ids)
        {
            var response = await _mediator.Send(new GetAllSongsByGenresQuery(ids));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("tab-difficulty")]
        public async Task<IActionResult> GetAllSongsByTabDifficulty(double? difficulty)
        {
            var response = await _mediator.Send(new GetAllSongsByTabDifficultyQuery(difficulty));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
