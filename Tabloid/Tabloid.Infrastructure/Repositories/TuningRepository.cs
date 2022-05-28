using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories
{
    internal class TuningRepository : Repository<Tuning, Guid>, ITuningRepository
    {
        public TuningRepository(TabDbContext context)
            : base(context)
        {
        }

        public async Task<Tuning> FindGuitarTuningByName(string tuning)
        {
            return await _context
                .Tunings
                .FirstOrDefaultAsync(x => x.Name == tuning);
        }

        public async Task<ICollection<Tuning>> GetAllGuitarTuningsByStringNumber(int number)
        {
            return await _context
                .Tunings
                .Where(x => x.StringNumber == number)
                .ToListAsync();
        }
    }
}
