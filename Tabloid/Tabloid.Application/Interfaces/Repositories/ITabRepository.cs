using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ITabRepository
    {
        Task<IList<Tab>> GetAllTabsBySong(Song song);
    }
}
