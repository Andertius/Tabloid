using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Context.Configurators
{
    internal sealed class TuningConfiguration : IEntityTypeConfiguration<Tuning>
    {
        public void Configure(EntityTypeBuilder<Tuning> builder)
        {
            builder
                .HasIndex(x => x.Name)
                .IsUnique();

            builder
                .HasIndex(x => x.Strings)
                .IsUnique();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Strings)
                .IsRequired();
        }
    }
}
