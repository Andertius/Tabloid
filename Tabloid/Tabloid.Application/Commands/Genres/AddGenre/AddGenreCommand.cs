using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Genres.AddGenre
{
    public class AddGenreCommand : IRequest<CommandResponse<GenreDto>>
    {
        public AddGenreCommand(GenreDto genre)
        {
            Genre = genre;
        }

        public GenreDto Genre { get; set; }
    }
}
