using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Repositories;

namespace Tabloid.ServiceConfigurations
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IRepository<Album, Guid>, Repository<Album, Guid>>()
                .AddScoped<IRepository<Artist, Guid>, Repository<Artist, Guid>>()
                .AddScoped<IRepository<Genre, Guid>, Repository<Genre, Guid>>()
                .AddScoped<IRepository<GuitarTuning, Guid>, Repository<GuitarTuning, Guid>>()
                .AddScoped<IRepository<Song, Guid>, Repository<Song, Guid>>()
                .AddScoped<IRepository<Tab, Guid>, Repository<Tab, Guid>>();

            services
                .AddScoped<Repository<Album, Guid>, AlbumRepository>()
                .AddScoped<Repository<Artist, Guid>, ArtistRepository>()
                .AddScoped<Repository<Genre, Guid>, GenreRepository>()
                .AddScoped<Repository<GuitarTuning, Guid>, GuitarTuningRepository>()
                .AddScoped<Repository<Song, Guid>, SongRepository>()
                .AddScoped<Repository<Tab, Guid>, TabRepository>();

            services
                .AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IGuitarTuningRepository, GuitarTuningRepository>()
                .AddScoped<ISongRepository, SongRepository>()
                .AddScoped<ITabRepository, TabRepository>();

            return services;
        }
    }
}
