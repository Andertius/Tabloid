using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public class ArtistRepository : Repository<Artist, Guid>, IArtistRepository
    {
        public ArtistRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<Artist> FindArtistByAlbum(Album album)
        {
            return await _context
                .Artists
                .Include(x => x.Albums)
                .Where(x => x.Albums.Contains(album))
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> FindArtistByName(string artistName)
        {
            return await _context
                .Artists
                .Where(x => x.Name == artistName)
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> FindArtistBySong(Song song)
        {
            return await _context
                .Artists
                .Include(x => x.Songs)
                .Where(x => x.Songs.Contains(song))
                .FirstOrDefaultAsync();
        }
    }
}
