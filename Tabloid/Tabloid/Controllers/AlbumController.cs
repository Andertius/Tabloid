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
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumRequest request)
        {
            var response = await _mediator.Send(new AddAlbumCommand(request.Album));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumRequest request)
        {
            var response = await _mediator.Send(new UpdateAlbumCommand(request.Album));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            var response = await _mediator.Send(new DeleteAlbumCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            var response = await _mediator.Send(new GetAllAlbumsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllAlbumsByName(string name)
        {
            var response = await _mediator.Send(new GetAllAlbumsByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("song")]
        public async Task<IActionResult> GetAlbumBySong([FromQuery] AlbumBySongRequest request)
        {
            var response = await _mediator.Send(new GetAlbumBySongQuery(request.Song));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("artist")]
        public async Task<IActionResult> GetAlbumByArtist([FromQuery] AlbumsByArtistRequest request)
        {
            var response = await _mediator.Send(new GetAllAlbumsByArtistQuery(request.Artist));
            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
