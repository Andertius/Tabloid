using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories.Interfaces
{
    public interface ITabRepository : IRepository<Tab, Guid>
    {
        Task<ICollection<Tab>> GetAllTabsBySong(Song song);
    }
}
