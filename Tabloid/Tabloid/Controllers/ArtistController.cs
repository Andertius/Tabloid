﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.Commands.Artists.AddArtist;
using Tabloid.Application.Commands.Artists.DeleteArtist;
using Tabloid.Application.Commands.Artists.UpdateArtist;
using Tabloid.Application.Queries.Artists.FindArtistByAlbum;
using Tabloid.Application.Queries.Artists.FindArtistByName;
using Tabloid.Application.Queries.Artists.FindArtistBySong;
using Tabloid.Application.Queries.Artists.GetAllArtists;
using Tabloid.Helpers;
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

        [HttpPost("artists/add")]
        public async Task<IActionResult> AddArtist([FromBody] ArtistRequest request)
        {
            var response = await _mediator.Send(new AddArtistCommand(request.Artist));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("artists/update")]
        public async Task<IActionResult> UpdateArtist([FromBody] ArtistRequest request)
        {
            var response = await _mediator.Send(new UpdateArtistCommand(request.Artist));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("artists/delete")]
        public async Task<IActionResult> DeleteArtist([FromBody] ArtistRequest request)
        {
            var response = await _mediator.Send(new DeleteArtistCommand(request.Artist));
            return ReturnResultHelper.ReturnCommandResult(response);
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

        [HttpGet("artists/album")]
        public async Task<IActionResult> FindArtistByAlbum([FromQuery] ArtistByAlbumRequest request)
        {
            var result = await _mediator.Send(new FindArtistByAlbumQuery(request.Album));
            return Ok(result);
        }

        [HttpGet("artists/song")]
        public async Task<IActionResult> FindArtistBySong([FromQuery] ArtistBySongRequest request)
        {
            var result = await _mediator.Send(new FindArtistBySongQuery(request.Song));
            return Ok(result);
        }
    }
}
