using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.CQRS.Songs.Queries.GetAllSongsByTuning
{
    public class GetAllSongsByTuningQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByTuningQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
