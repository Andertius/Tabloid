using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories;

internal class SongRepository : Repository<Song, Guid>, ISongRepository
{
    public SongRepository(TabDbContext context)
        : base(context)
    {
    }

    public override async Task<Song?> FindById(Guid id)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<ICollection<Song>> GetAll()
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByAlbum(Album album)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x => x.Album == album)
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByArtists(IEnumerable<Artist> artists)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x => x.Artists!.All(a => artists.Contains(a)))
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByGenres(IEnumerable<Genre> genres)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x => x.Genres!.All(g => genres.Contains(g)))
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByName(string name)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x => x.SongName == name)
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByTabDifficulty(double? difficulty)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x =>
                x.Tabs!.Any(y => Math.Abs(y.Difficulty - difficulty ?? Double.MaxValue) < 0.00001))
            .ToListAsync();
    }

    public async Task<ICollection<Song>> GetAllSongsByTuning(Tuning tuning)
    {
        return await _context
            .Set<Song>()
            .Include(x => x.Genres)
            .Include(x => x.Artists)
            .Include(x => x.Album)
            .Include(x => x.Tabs)!
                .ThenInclude(x => x.Tuning)
            .Where(x => x.Tabs!.Any(x => x.Tuning == tuning))
            .ToListAsync();
    }
}
