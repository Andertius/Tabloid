using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories.Interfaces
{
    public interface ISongRepository : IRepository<Song, Guid>
    {
        Task<ICollection<Song>> GetAllSongsByName(string name);

        Task<ICollection<Song>> GetAllSongsByAlbum(Album album);

        Task<ICollection<Song>> GetAllSongsByTabDifficulty(double? difficulty);

        Task<ICollection<Song>> GetAllSongsByTuning(GuitarTuning tuning);

        Task<ICollection<Song>> GetAllSongsByGenres(IEnumerable<Genre> genres);

        Task<ICollection<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists);
    }
}
