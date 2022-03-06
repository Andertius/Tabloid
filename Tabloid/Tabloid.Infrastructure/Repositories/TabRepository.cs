using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Infrastructure.Repositories
{
    public class TabRepository : Repository<Tab, Guid>, ITabRepository
    {
        public TabRepository(TabDbContext context) : base(context)
        {
        }

        public override async Task<ICollection<Tab>> GetAll()
        {
            return await _context
                .Tabs
                .Include(x => x.Song)
                .ToListAsync();
        }

        public async Task<ICollection<Tab>> GetAllTabsBySong(Song song)
        {
            return await _context
                .Tabs
                .Include(x => x.Song)
                .Where(x => x.Song == song)
                .ToListAsync();
        }
    }
}
