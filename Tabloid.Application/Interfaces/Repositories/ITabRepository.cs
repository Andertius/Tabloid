using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface ITabRepository : IRepository<Tab, Guid>
    {
        Task<ICollection<Tab>> GetAllTabsBySong(Guid songId);
    }
}
