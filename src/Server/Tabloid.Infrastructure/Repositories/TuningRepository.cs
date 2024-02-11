using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories;

internal class TuningRepository : Repository<Tuning, Guid>, ITuningRepository
{
    public TuningRepository(TabDbContext context)
        : base(context)
    {
    }

    public override async Task<Tuning?> FindById(Guid id)
    {
        return await _context
            .Set<Tuning>()
            .Include(x => x.Tabs)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<ICollection<Tuning>> GetAll()
    {
        return await _context
            .Set<Tuning>()
            .Include(x => x.Tabs)
            .ToListAsync();
    }

    public async Task<ICollection<Tuning>> GetAllJustTunings()
    {
        return await _context
            .Set<Tuning>()
            .ToListAsync();
    }

    public async Task<Tuning?> FindGuitarTuningByName(string tuning)
    {
        return await _context
            .Set<Tuning>()
            .Include(x => x.Tabs)
            .FirstOrDefaultAsync(x => x.Name == tuning);
    }

    public async Task<ICollection<Tuning>> GetAllGuitarTuningsByStringNumber(int number)
    {
        return await _context
            .Set<Tuning>()
            .Include(x => x.Tabs)
            .Where(x => x.StringNumber == number)
            .ToListAsync();
    }
}
