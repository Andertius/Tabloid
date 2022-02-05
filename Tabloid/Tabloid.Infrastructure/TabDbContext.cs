using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure
{
    public class TabDbContext : DbContext
    {
        public TabDbContext(DbContextOptions<TabDbContext> opts)
            : base(opts)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Tab> Tabs { get; set; }

        public DbSet<GuitarTuning> Tunings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Artist>()
                .HasMany(x => x.Songs)
                .WithMany(x => x.Artists);

            modelBuilder
                .Entity<Artist>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder
                .Entity<Genre>()
                .HasMany(x => x.Songs)
                .WithMany(x => x.Genres);

            modelBuilder
                .Entity<Genre>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder
                .Entity<GuitarTuning>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder
                .Entity<GuitarTuning>()
                .HasIndex(x => x.Tuning)
                .IsUnique();

            modelBuilder
                .Entity<Album>()
                .HasOne(x => x.Artist)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Album>()
                .HasMany(x => x.Songs)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Album>()
                .HasIndex(p => new { p.Name, p.ArtistId })
                .IsUnique();

            modelBuilder
                .Entity<Tab>()
                .HasOne(x => x.Song)
                .WithMany(x => x.Tabs)
                .HasForeignKey(x => x.SongId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Tab>()
                .HasOne(x => x.Tuning)
                .WithMany(x => x.Tabs)
                .HasForeignKey(x => x.TuningId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
