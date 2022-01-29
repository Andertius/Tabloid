namespace Tabloid.Application.Interfaces
{
    public interface IUnitOfWork<TId>
    {
        TRepository GetRepository<TRepository>() where TRepository : class;

        Task Save();
    }
}
