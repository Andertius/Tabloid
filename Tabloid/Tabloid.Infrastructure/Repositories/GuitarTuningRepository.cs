using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

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
                .Where(x => x.Tuning == tuning)
                .FirstOrDefaultAsync();
        }

        public async Task<IList<GuitarTuning>> GetAllGuitarTuningsByStringNumber(int number)
        {
            return await _context
                .Tunings
                .Where(x => x.StringNumber == number)
                .ToListAsync();
        }
    }
}
