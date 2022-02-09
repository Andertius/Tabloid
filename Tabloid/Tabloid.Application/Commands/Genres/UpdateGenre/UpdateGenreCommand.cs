using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Genres.UpdateGenre
{
    public class UpdateGenreCommand : IRequest<CommandResponse<GenreDto>>
    {
        public UpdateGenreCommand(GenreDto genre)
        {
            Genre = genre;
        }

        public GenreDto Genre { get; set; }
    }
}
