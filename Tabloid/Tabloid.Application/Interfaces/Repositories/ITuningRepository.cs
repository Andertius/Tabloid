using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ITuningRepository : IRepository<Tuning, Guid>
    {
        Task<ICollection<Tuning>> GetAllGuitarTuningsByStringNumber(int number);

        Task<Tuning> FindGuitarTuningByName(string tuning);
    }
}
