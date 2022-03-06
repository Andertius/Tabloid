using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Interfaces.Repositories;

namespace Tabloid.Infrastructure.Repositories
{
    public class GuitarTuningRepository : Repository<GuitarTuning, Guid>, IGuitarTuningRepository
    {
        public GuitarTuningRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<GuitarTuning> FindGuitarTuningByName(string tuning)
        {
            return await _context
                .Tunings
                .FirstOrDefaultAsync(x => x.Name == tuning);
        }

        public async Task<ICollection<GuitarTuning>> GetAllGuitarTuningsByStringNumber(int number)
        {
            return await _context
                .Tunings
                .Where(x => x.StringNumber == number)
                .ToListAsync();
        }
    }
}
