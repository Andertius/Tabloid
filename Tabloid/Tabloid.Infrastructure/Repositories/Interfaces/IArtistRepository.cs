using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories.Interfaces
{
    public interface IArtistRepository : IRepository<Artist, Guid>
    {
        public Task<Artist> FindArtistByName(string artistName);

        public Task<Artist> FindArtistBySong(Song song);

        public Task<Artist> FindArtistByAlbum(Album album);
    }
}
