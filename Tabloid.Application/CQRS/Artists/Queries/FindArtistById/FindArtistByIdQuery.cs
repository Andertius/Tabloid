using System;

using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Artists.Queries.FindArtistById
{
    public class FindArtistByIdQuery : IRequest<ArtistDto>
    {
        public FindArtistByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
