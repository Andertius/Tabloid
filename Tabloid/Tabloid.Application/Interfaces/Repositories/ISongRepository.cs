using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ISongRepository
    {
        Task<IList<Song>> GetAllSongsByName(string name);

        Task<IList<Song>> GetAllSongsByAlbum(Album album);

        Task<IList<Song>> GetAllSongsByTabDifficulty(double difficulty);

        Task<IList<Song>> GetAllSongsByTuning(GuitarTuning tuning);

        Task<IList<Song>> GetAllSongsByGenre(Genre genre);

        Task<IList<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists);
    }
}
