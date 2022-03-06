using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Infrastructure.Repositories
{
    public class ArtistRepository : Repository<Artist, Guid>, IArtistRepository
    {
        public ArtistRepository(TabDbContext context)
            : base(context)
        {
        }

        public override async Task<ICollection<Artist>> GetAll()
        {
            return await _context
                .Artists
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .ToListAsync();
        }

        public async Task<Artist> FindArtistByAlbum(Album album)
        {
            return await _context
                .Artists
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Where(x => x.Albums.Contains(album))
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> FindArtistByName(string artistName)
        {
            return await _context
                .Artists
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Where(x => x.Name == artistName)
                .FirstOrDefaultAsync();
        }

        public async Task<Artist> FindArtistBySong(Song song)
        {
            return await _context
                .Artists
                .Include(x => x.Albums)
                .Include(x => x.Songs)
                .Where(x => x.Songs.Contains(song))
                .FirstOrDefaultAsync();
        }
    }
}
