using Tabloid.Domain.Entities;

namespace Tabloid.Domain.Interfaces.Repositories
{
    public interface IGuitarTuningRepository : IRepository<GuitarTuning, Guid>
    {
        Task<ICollection<GuitarTuning>> GetAllGuitarTuningsByStringNumber(int number);

        Task<GuitarTuning> FindGuitarTuningByName(string tuning);
    }
}
