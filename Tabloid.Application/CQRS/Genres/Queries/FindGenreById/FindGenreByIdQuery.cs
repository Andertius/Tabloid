using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Genres.Queries.FindGenreById;

public class FindGenreByIdQuery : IRequest<GenreDto>
{
    public FindGenreByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
