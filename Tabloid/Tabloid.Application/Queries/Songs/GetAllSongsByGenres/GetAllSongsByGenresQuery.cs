using MediatR;

using Tabloid.Domain.DataTransferObjects;

namespace Tabloid.Application.Queries.Songs.GetAllSongsByGenres
{
    public class GetAllSongsByGenresQuery : IRequest<SongDto[]>
    {
        public GetAllSongsByGenresQuery(ICollection<GenreDto> genres)
        {
            Genres = genres;
        }

        public ICollection<GenreDto> Genres { get; set; }
    }
}
