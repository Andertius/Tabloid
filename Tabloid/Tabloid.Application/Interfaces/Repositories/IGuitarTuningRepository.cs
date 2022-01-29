using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IGuitarTuningRepository
    {
        Task<IList<GuitarTuning>> GetAllGuitarTuningsByStringNumber(int number);

        Task<GuitarTuning> FindGuitarTuningByName(string tuning);
    }
}
