using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<Genre> FindGenreByName(string genreName)
        {
            return await _context
                .Genres
                .Where(x => x.Name == genreName)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<Genre>> GetAllGenresBySong(Song song)
        {
            return await _context
                .Genres
                .Include(x => x.Songs)
                .Where(x => x.Songs.Contains(song))
                .ToListAsync();
        }
    }
}
