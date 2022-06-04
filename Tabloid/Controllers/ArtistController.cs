using System.Net.Http.Headers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByArtist;
using Tabloid.Application.CQRS.Artists.Commands.AddArtist;
using Tabloid.Application.CQRS.Artists.Commands.DeleteArtist;
using Tabloid.Application.CQRS.Artists.Commands.UpdateArtist;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistById;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistByName;
using Tabloid.Application.CQRS.Artists.Queries.GetAllArtists;
using Tabloid.Application.CQRS.Images.Commands.AddImage;
using Tabloid.Application.CQRS.Images.Commands.DeleteImage;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _host;

        public ArtistController(
            IMediator mediator,
            IWebHostEnvironment host)
        {
            _mediator = mediator;
            _host = host;
        }

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistDto artist)
        {
            var response = await _mediator.Send(new AddArtistCommand(artist));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArtist([FromBody] ArtistDto artist)
        {
            var response = await _mediator.Send(new UpdateArtistCommand(artist));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new DeleteArtistCommand(id));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllArtistsQuery());
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindArtistById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new FindArtistByIdQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("name")]
        public async Task<IActionResult> FindArtistByName([FromQuery] string name)
        {
            var response = await _mediator.Send(new FindArtistByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAllAlbumsByArtist([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetAllAlbumsByArtistQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPatch("{artistId}/cover")]
        public async Task<IActionResult> UploadAlbumCover(Guid artistId)
        {
            var file = Request.Form.Files[0];

            if (file.Length > 0)
            {
                string extention = Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'));
                string fileName = Guid.NewGuid().ToString() + extention;
                string fullPath = Path.Combine(_host.WebRootPath, "album-covers", fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var result = await _mediator.Send(new AddImageCommand(artistId, fileName, typeof(Artist)));

                if (result.Result == CommandResult.Success)
                {
                    return Ok(result.Object);
                }
            }

            return BadRequest();
        }

        [HttpDelete("{artistId}/avatar")]
        public async Task<IActionResult> DeleteAvatar(Guid artistId)
        {
            var response = await _mediator.Send(new DeleteImageCommand(artistId, typeof(Artist)));

            if (response.Result == CommandResult.Success)
            {
                string fullPath = Path.Combine(_host.WebRootPath, "artist-avatars", response.Object);

                System.IO.File.Delete(fullPath);

                return NoContent();
            }

            return BadRequest();
        }
    }
}
