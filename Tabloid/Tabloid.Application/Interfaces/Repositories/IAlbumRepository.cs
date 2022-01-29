using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IAlbumRepository
    {
        Task<IList<Album>> GetAllAlbumsByName(string name);

        Task<Album> FindAlbumBySong(Song song);

        Task<IList<Album>> GetAllAlbumsByArtist(Artist artist);
    }
}
