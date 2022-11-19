using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ISongRepository : IRepository<Song, Guid>
    {
        Task<ICollection<Song>> GetAllSongsByName(string name);

        Task<ICollection<Song>> GetAllSongsByAlbum(Album album);

        Task<ICollection<Song>> GetAllSongsByTabDifficulty(double? difficulty);

        Task<ICollection<Song>> GetAllSongsByTuning(Tuning tuning);

        Task<ICollection<Song>> GetAllSongsByGenres(IEnumerable<Genre> genres);

        Task<ICollection<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists);
    }
}
