using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ITuningRepository : IRepository<Tuning, Guid>
    {
        Task<ICollection<Tuning>> GetAllGuitarTuningsByStringNumber(int number);

        Task<Tuning> FindGuitarTuningByName(string tuning);

        Task<ICollection<Tuning>> GetAllJustTunings();
    }
}
