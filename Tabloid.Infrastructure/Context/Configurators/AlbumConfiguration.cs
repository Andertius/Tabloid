using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Context.Configurators
{
    internal sealed class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasOne(x => x.Artist)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Songs)
                .WithOne(x => x.Album)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasIndex(x => new { x.Name, x.ArtistId })
                .IsUnique();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.ArtistId)
                .IsRequired();
        }
    }
}
