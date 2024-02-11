using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context.Configurators;
using Tabloid.Infrastructure.DbContextInitializers;

namespace Tabloid.Infrastructure.Context;

public class TabDbContext : DbContext
{
    private readonly IDbContextInitializer _dbContextInitializer;

    public TabDbContext(
        DbContextOptions<TabDbContext> opts,
        IDbContextInitializer dbContextInitializer)
        : base(opts)
    {
        _dbContextInitializer = dbContextInitializer;
    }

    public DbSet<Artist>? Artists { get; set; }

    public DbSet<Genre>? Genres { get; set; }

    public DbSet<Album>? Albums { get; set; }

    public DbSet<Song>? Songs { get; set; }

    public DbSet<Tab>? Tabs { get; set; }

    public DbSet<Tuning>? Tunings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabConfiguration).Assembly);
        _dbContextInitializer.Seed(modelBuilder);
    }
}
