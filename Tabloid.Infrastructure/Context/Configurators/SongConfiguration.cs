using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Context.Configurators;

internal sealed class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder
            .Property(x => x.SongName)
            .IsRequired();

        builder
            .Property(x => x.AlbumId)
            .IsRequired();

        builder
            .HasIndex(x => new { x.AlbumId, x.SongNumberInAlbum })
            .IsUnique();
    }
}
