using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistBySong;

public class FindArtistBySongQuery : IRequest<ArtistDto>
{
    public FindArtistBySongQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
