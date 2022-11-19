using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Commands.UpdateGenre;

public class UpdateGenreCommand : IRequest<CommandResponse<GenreDto>>
{
    public UpdateGenreCommand(GenreDto genre)
    {
        Genre = genre;
    }

    public GenreDto Genre { get; set; }
}
