using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories
{
    internal class AlbumRepository : Repository<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(TabDbContext context)
            : base(context)
        {
        }

        public override async Task<Album> FindById(Guid id)
        {
            return await _context
                .Set<Album>()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Album>> GetAll()
        {
            return await _context
                .Set<Album>()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .ToListAsync();
        }

        public async Task<ICollection<Album>> GetAllAlbumsByName(string name)
        {
            return await _context
                .Set<Album>()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Name == name)
                .ToListAsync();
        }

        public async Task<Album> FindAlbumBySong(Song song)
        {
            return await _context
                .Set<Album>()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Songs.Contains(song))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Album>> GetAllAlbumsByArtist(Artist artist)
        {
            return await _context
                .Set<Album>()
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                    .ThenInclude(x => x.Artists)
                .Where(x => x.Artist.Id == artist.Id)
                .ToListAsync();
        }
    }
}
