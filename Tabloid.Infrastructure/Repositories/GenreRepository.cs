using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories
{
    internal class GenreRepository : Repository<Genre, Guid>, IGenreRepository
    {
        public GenreRepository(TabDbContext context)
            : base(context)
        {
        }

        public override async Task<Genre> FindById(Guid id)
        {
            return await _context
                .Set<Genre>()
                .Include(x => x.Songs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Genre>> GetAll()
        {
            return await _context
                .Set<Genre>()
                .Include(x => x.Songs)
                .ToListAsync();
        }

        public async Task<Genre> FindGenreByName(string genreName)
        {
            return await _context
                .Set<Genre>()
                .Where(x => x.Name == genreName)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Genre>> GetAllGenresBySong(Song song)
        {
            return await _context
                .Set<Genre>()
                .Include(x => x.Songs)
                .Where(x => x.Songs.Contains(song))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllRockGenres()
        {
            return await _context
                .Set<Genre>()
                .Where(x => x.Name.Contains("Rock"))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllMetalGenres()
        {
            return await _context
                .Set<Genre>()
                .Where(x => x.Name.Contains("Metal") || AllMetalGenresWithoutMetalInTheirName.Contains(x.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetAllElectroGenres()
        {
            return await _context
                .Set<Genre>()
                .Where(x => AllElectroGenres.Contains(x.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<ICollection<Genre>> GetEveryOtherGenre()
        {
            return await _context
                .Set<Genre>()
                .Where(x => !x.Name.Contains("Rock"))
                .Where(x => !x.Name.Contains("Metal") && !AllMetalGenresWithoutMetalInTheirName.Contains(x.Name))
                .Where(x => !AllElectroGenres.Contains(x.Name))
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

        private static ICollection<string> AllElectroGenres
            => new[]
            {
                "Electro",
                "Dubstep",
                "Chillstep",
                "Glichhop",
                "Ambient",
                "Wave",
                "Lofi" ,
                "Drumstep",
                "Hardcore",
                "House",
                "Trap",
                "Tance",
            };
    }
}
