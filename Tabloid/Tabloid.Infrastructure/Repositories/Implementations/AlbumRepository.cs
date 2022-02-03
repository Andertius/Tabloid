using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Infrastructure.Repositories.Implementations
{
    public class AlbumRepository : Repository<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Album>> GetAllAlbumsByName(string name)
        {
            return await _context
                .Albums
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public async Task<Album> FindAlbumBySong(Song song)
        {
            return await _context.Albums
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Songs.Contains(song))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Album>> GetAllAlbumsByArtist(Artist artist)
        {
            return await _context
                .Albums
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Artist.Id == artist.Id)
                .ToListAsync();
        }
    }
}
