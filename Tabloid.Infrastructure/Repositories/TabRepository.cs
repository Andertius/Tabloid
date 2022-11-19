using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories
{
    internal class TabRepository : Repository<Tab, Guid>, ITabRepository
    {
        public TabRepository(TabDbContext context) : base(context)
        {
        }

        public override async Task<Tab> FindById(Guid id)
        {
            return await _context
                .Set<Tab>()
                .Include(x => x.Song)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Tab>> GetAll()
        {
            return await _context
                .Set<Tab>()
                .Include(x => x.Song)
                .ToListAsync();
        }

        public async Task<ICollection<Tab>> GetAllTabsBySong(Guid songId)
        {
            return await _context
                .Set<Tab>()
                .Include(x => x.Song)
                .Where(x => x.SongId == songId)
                .ToListAsync();
        }
    }
}
