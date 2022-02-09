using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands.Albums.AddAlbum;
using Tabloid.Application.Commands.Albums.DeleteAlbum;
using Tabloid.Application.Commands.Albums.UpdateAlbum;
using Tabloid.Application.Queries.Albums.GetAlbumBySong;
using Tabloid.Application.Queries.Albums.GetAllAlbums;
using Tabloid.Application.Queries.Albums.GetAllAlbumsByArtist;
using Tabloid.Application.Queries.Albums.GetAllAlbumsByName;
using Tabloid.Helpers;
using Tabloid.Requests.AlbumRequests;

namespace Tabloid.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("albums/add")]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumRequest request)
        {
            var response = await _mediator.Send(new AddAlbumCommand(request.Album));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("albums/update")]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumRequest request)
        {
            var response = await _mediator.Send(new UpdateAlbumCommand(request.Album));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("albums/delete")]
        public async Task<IActionResult> DeleteAlbum([FromBody] AlbumRequest request)
        {
            var response = await _mediator.Send(new DeleteAlbumCommand(request.Album));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("albums")]
        public async Task<IActionResult> GetAllAlbums()
        {
            var response = await _mediator.Send(new GetAllAlbumsQuery());
            return Ok(response);
        }

        [HttpGet("albums/{name}")]
        public async Task<IActionResult> GetAllAlbumsByName(string name)
        {
            var response = await _mediator.Send(new GetAllAlbumsByNameQuery(name));
            return Ok(response);
        }

        [HttpGet("albums/song")]
        public async Task<IActionResult> GetAlbumBySong([FromQuery] AlbumBySongRequest request)
        {
            var response = await _mediator.Send(new GetAlbumBySongQuery(request.Song));
            return Ok(response);
        }

        [HttpGet("albums/artist")]
        public async Task<IActionResult> GetAlbumByArtist([FromQuery] AlbumsByArtistRequest request)
        {
            var response = await _mediator.Send(new GetAllAlbumsByArtistQuery(request.Artist));
            return Ok(response);
        }
    }
}
