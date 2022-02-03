using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Queries.Artists.FindArtistByAlbum;
using Tabloid.Application.Queries.Artists.FindArtistByName;
using Tabloid.Application.Queries.Artists.FindArtistBySong;
using Tabloid.Application.Queries.Artists.GetAllArtists;
using Tabloid.Requests.ArtistRequests;

namespace Tabloid.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("artists")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllArtistsQuery());
            return Ok(result);
        }

        [HttpGet("artists/{name}")]
        public async Task<IActionResult> FindArtistByName(string name)
        {
            var result = await _mediator.Send(new FindArtistByNameQuery(name));
            return Ok(result);
        }

        [HttpPost("artists/album")]
        public async Task<IActionResult> FindArtistByAlbum(ArtistByAlbumRequest request)
        {
            var result = await _mediator.Send(new FindArtistByAlbumQuery(request.Album));
            return Ok(result);
        }

        [HttpPost("artists/song")]
        public async Task<IActionResult> FindArtistBySong(ArtistBySongRequest request)
        {
            var result = await _mediator.Send(new FindArtistBySongQuery(request.Song));
            return Ok(result);
        }
    }
}
