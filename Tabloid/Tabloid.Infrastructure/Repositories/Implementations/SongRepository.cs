﻿using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Infrastructure.Repositories.Implementations
{
    public class SongRepository : Repository<Song, Guid>, ISongRepository
    {
        public SongRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<Song>> GetAllSongsByAlbum(Album album)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Album == album)
                .ToListAsync();
        }

        public async Task<ICollection<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Artists.All(a => artists.Contains(a)))
                .ToListAsync();
        }

        public async Task<ICollection<Song>> GetAllSongsByGenres(IEnumerable<Genre> genres)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.Genres.All(g => genres.Contains(g)))
                .ToListAsync();
        }

        public async Task<ICollection<Song>> GetAllSongsByName(string name)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Where(x => x.SongName == name)
                .ToListAsync();
        }

        public async Task<ICollection<Song>> GetAllSongsByTabDifficulty(double? difficulty)
        {
            return await _context
                .Songs
                .Include(x => x.Genres)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .Include(x => x.Tabs)
                .Where(x => !difficulty.HasValue || x.Tabs.Any(y => y.Difficulty == difficulty))
                .ToListAsync();
        }

        public async Task<ICollection<Song>> GetAllSongsByTuning(GuitarTuning tuning)
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
