using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public class TabRepository : Repository<Tab, Guid>, ITabRepository
    {
        public TabRepository(TabDbContext context) : base(context)
        {
        }

        public async Task<IList<Tab>> GetAllTabsBySong(Song song)
        {
            return await _context
                .Tabs
                .Include(x => x.Song)
                .Where(x => x.Song == song)
                .ToListAsync();
        }
    }
}
