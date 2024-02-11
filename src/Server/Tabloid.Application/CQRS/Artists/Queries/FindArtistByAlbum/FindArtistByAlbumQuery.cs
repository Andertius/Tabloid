using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistByAlbum;

public class FindArtistByAlbumQuery : IRequest<ArtistDto>
{
    public FindArtistByAlbumQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
