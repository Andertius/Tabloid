using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Interfaces.Repositories;
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

        public async Task<ICollection<Genre>> GetAllGenresBySong(Song song)
        {
            return await _context
                .Genres
                .Include(x => x.Songs)
                .Where(x => x.Songs.Contains(song))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllRockGenres()
        {
            return await _context
                .Genres
                .Where(x => x.Name.Contains("Rock"))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllMetalGenres()
        {
            return await _context
                .Genres
                .Where(x => x.Name.Contains("Metal") || AllMetalGenresWithoutMetalInTheirName.Contains(x.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        private static ICollection<string> AllMetalGenresWithoutMetalInTheirName
            => new[]
            {
                "Djent",
                "Crossover Thrash",
                "Neue Deutsche Härte",
                "Deathcore",
                "Mathcore",
                "Electronicore",
                "Deathcore",
                "Grindcore",
                "Goregrind",
                "Pornogrind",
            };
    }
}
