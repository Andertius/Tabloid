using System.Net.Http.Headers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Albums.Commands.AddAlbum;
using Tabloid.Application.CQRS.Albums.Commands.DeleteAlbum;
using Tabloid.Application.CQRS.Albums.Commands.UpdateAlbum;
using Tabloid.Application.CQRS.Albums.Queries.FindAlbumById;
using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbums;
using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByName;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistByAlbum;
using Tabloid.Application.CQRS.Images.Commands.AddImage;
using Tabloid.Application.CQRS.Images.Commands.DeleteImage;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByAlbum;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _host;

        public AlbumController(
            IMediator mediator,
            IWebHostEnvironment host)
        {
            _mediator = mediator;
            _host = host;
        }

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumDto ablum)
        {
            var response = await _mediator.Send(new AddAlbumCommand(ablum));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumDto ablum)
        {
            var response = await _mediator.Send(new UpdateAlbumCommand(ablum));
            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] Guid id)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAlbumById([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new FindAlbumByIdQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllAlbumsByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetAllAlbumsByNameQuery(name));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}/artist")]
        public async Task<IActionResult> FindArtistByAlbum([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new FindArtistByAlbumQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetAllSongsByAlbum([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetAllSongsByAlbumQuery(id));
            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPatch("{albumId}/cover")]
        public async Task<IActionResult> UploadAlbumCover(Guid albumId)
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

                var result = await _mediator.Send(new AddImageCommand(albumId, fileName, typeof(Album)));

                if (result.Result == CommandResult.Success)
                {
                    return Ok(result.Object);
                }
            }

            return BadRequest();
        }

        [HttpDelete("{albumId}/avatar")]
        public async Task<IActionResult> DeleteAvatar(Guid albumId)
        {
            var response = await _mediator.Send(new DeleteImageCommand(albumId, typeof(Album)));

            if (response.Result == CommandResult.Success)
            {
                string fullPath = Path.Combine(_host.WebRootPath, "album-covers", response.Object);

                System.IO.File.Delete(fullPath);

                return NoContent();
            }

            return BadRequest();
        }
    }
}
