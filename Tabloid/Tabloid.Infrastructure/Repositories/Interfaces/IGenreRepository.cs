using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories.Interfaces
{
    public interface IGenreRepository : IRepository<Genre, Guid>
    {
        Task<Genre> FindGenreByName(string genreName);

        Task<ICollection<Genre>> GetAllGenresBySong(Song song);

        Task<ICollection<Genre>> GetAllRockGenres();

        Task<ICollection<Genre>> GetAllMetalGenres();

        Task<ICollection<Genre>> GetEveryOtherGenre();

        Task<ICollection<Genre>> GetAllElectroGenres();
    }
}
