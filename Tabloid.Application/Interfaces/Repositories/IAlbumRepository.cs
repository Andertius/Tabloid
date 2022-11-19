using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IAlbumRepository : IRepository<Album, Guid>
    {
        Task<ICollection<Album>> GetAllAlbumsByName(string name);

        Task<Album> FindAlbumBySong(Song song);

        Task<ICollection<Album>> GetAllAlbumsByArtist(Artist artist);
    }
}
