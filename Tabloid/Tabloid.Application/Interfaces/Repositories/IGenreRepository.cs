using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> FindGenreByName(string genreName);

        Task<IList<Genre>> GetAllGenresBySong(Song song);
    }
}
