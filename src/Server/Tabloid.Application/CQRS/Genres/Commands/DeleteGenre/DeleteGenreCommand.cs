using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Commands.DeleteGenre;

public class DeleteGenreCommand : IRequest<CommandResponse<GenreDto>>
{
    public DeleteGenreCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
