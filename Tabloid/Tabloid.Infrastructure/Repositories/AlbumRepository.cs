using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public class AlbumRepository : Repository<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<IList<Album>> GetAllAlbumsByName(string name)
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

        public async Task<IList<Album>> GetAllAlbumsByArtist(Artist artist)
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
