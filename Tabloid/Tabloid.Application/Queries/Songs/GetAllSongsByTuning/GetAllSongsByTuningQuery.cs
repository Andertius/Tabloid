using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByTuning
{
    public class GetAllSongsByTuningQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByTuningQuery(GuitarTuningDto tuning)
        {
            Tuning = tuning;
        }

        public GuitarTuningDto Tuning { get; set; }
    }
}
