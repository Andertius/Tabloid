using Tabloid.Domain.Entities;

namespace Tabloid.Domain.Interfaces.Repositories
{
    public interface IArtistRepository : IRepository<Artist, Guid>
    {
        public Task<Artist> FindArtistByName(string artistName);

        public Task<Artist> FindArtistBySong(Song song);

        public Task<Artist> FindArtistByAlbum(Album album);
    }
}
