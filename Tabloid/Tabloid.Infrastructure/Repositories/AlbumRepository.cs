using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Infrastructure.Repositories
{
    internal class AlbumRepository : Repository<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(TabDbContext context)
            : base(context)
        {
        }

        public override async Task<ICollection<Album>> GetAll()
        {
            return await _context
                .Albums
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .ToListAsync();
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
