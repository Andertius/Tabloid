using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Albums.Commands.AddAlbum;
using Tabloid.Application.CQRS.Albums.Commands.DeleteAlbum;
using Tabloid.Application.CQRS.Albums.Commands.UpdateAlbum;
using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbums;
using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByName;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistByAlbum;
using Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByAlbum;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

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
    }
}
