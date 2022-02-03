using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Infrastructure.Repositories.Implementations
{
    public class TabRepository : Repository<Tab, Guid>, ITabRepository
    {
        public TabRepository(TabDbContext context) : base(context)
        {
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
