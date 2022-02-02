using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Queries.Albums.GetAlbumBySong;
using Tabloid.Application.Queries.Albums.GetAllAlbums;
using Tabloid.Application.Queries.Albums.GetAllAlbumsByArtist;
using Tabloid.Application.Queries.Albums.GetAllAlbumsByName;
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

        [HttpPost("albums/song")]
        public async Task<IActionResult> GetAlbumBySong(AlbumBySongRequest request)
        {
            var response = await _mediator.Send(new GetAlbumBySongQuery(request.Song));
            return Ok(response);
        }

        [HttpPost("albums/artist")]
        public async Task<IActionResult> GetAlbumByArtist(AlbumsByArtistRequest request)
        {
            var response = await _mediator.Send(new GetAllAlbumsByArtistQuery(request.Artist));
            return Ok(response);
        }
    }
}
