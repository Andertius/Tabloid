using MediatR;

using Microsoft.AspNetCore.Mvc;

using Tabloid.Application.CQRS.Albums.Queries.GetAllAlbumsByArtist;
using Tabloid.Application.CQRS.Artists.Commands.AddArtist;
using Tabloid.Application.CQRS.Artists.Commands.DeleteArtist;
using Tabloid.Application.CQRS.Artists.Commands.UpdateArtist;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistById;
using Tabloid.Application.CQRS.Artists.Queries.FindArtistByName;
using Tabloid.Application.CQRS.Artists.Queries.GetAllArtists;
using Tabloid.Domain.DataTransferObjects;
using Tabloid.Helpers;

namespace Tabloid.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistController(IMediator mediator)
        {
            _mediator = mediator;
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

        [HttpGet("{name}")]
        public async Task<IActionResult> FindArtistByName([FromRoute] string name)
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
    }
}
