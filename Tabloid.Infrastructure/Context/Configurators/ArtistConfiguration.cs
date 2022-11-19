using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Context.Configurators;

internal sealed class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder
            .HasMany(x => x.Songs)
            .WithMany(x => x.Artists);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .Property(x => x.Name)
            .IsRequired();
    }
}
