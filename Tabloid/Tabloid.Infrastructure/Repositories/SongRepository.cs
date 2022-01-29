using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public class SongRepository : Repository<Song, Guid>, ISongRepository
    {
        public SongRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<IList<Song>> GetAllSongsByAlbum(Album album)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Album == album)
                .ToListAsync();
        }

        public async Task<IList<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Artists.All(a => artists.Contains(a)))
                .ToListAsync();
        }

        public async Task<IList<Song>> GetAllSongsByGenres(IEnumerable<Genre> genres)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Genres.All(g => genres.Contains(g)))
                .ToListAsync();
        }

        public async Task<IList<Song>> GetAllSongsByName(string name)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.SongName == name)
                .ToListAsync();
        }

        public async Task<IList<Song>> GetAllSongsByTabDifficulty(double difficulty)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Include(x => x.Tabs)
                .Where(x => x.Tabs.Any(x => x.Difficulty == difficulty))
                .ToListAsync();
        }

        public async Task<IList<Song>> GetAllSongsByTuning(GuitarTuning tuning)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Include(x => x.Tabs)
                .Where(x => x.Tabs.Any(x => x.Tuning == tuning))
                .ToListAsync();
        }
    }
}
