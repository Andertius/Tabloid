using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Albums.Queries.FindAlbumById;

public class FindAlbumByIdQuery : IRequest<AlbumDto>
{
    public FindAlbumByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
