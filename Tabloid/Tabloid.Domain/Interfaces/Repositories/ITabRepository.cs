using Tabloid.Domain.Entities;

namespace Tabloid.Domain.Interfaces.Repositories
{
    public interface ITabRepository : IRepository<Tab, Guid>
    {
        Task<ICollection<Tab>> GetAllTabsBySong(Song song);
    }
}
