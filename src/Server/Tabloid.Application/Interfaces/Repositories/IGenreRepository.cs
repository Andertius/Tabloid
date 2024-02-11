using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Tabloid.Domain.Entities;

namespace Tabloid.Application.Interfaces.Repositories;

public interface IGenreRepository : IRepository<Genre, Guid>
{
    Task<Genre?> FindGenreByName(string genreName);

    Task<ICollection<Genre>> GetAllGenresBySong(Song song);

    Task<ICollection<Genre>> GetAllRockGenres();

    Task<ICollection<Genre>> GetAllMetalGenres();

    Task<ICollection<Genre>> GetEveryOtherGenre();

    Task<ICollection<Genre>> GetAllElectroGenres();
}
