using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Commands.Genres.DeleteGenre
{
    public class DeleteGenreCommand : IRequest<CommandResponse<GenreDto>>
    {
        public DeleteGenreCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
