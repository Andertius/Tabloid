﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Context.Configurators;

internal sealed class TabConfiguration : IEntityTypeConfiguration<Tab>
{
    public void Configure(EntityTypeBuilder<Tab> builder)
    {
        builder
            .HasOne(x => x.Song)
            .WithMany(x => x.Tabs)
            .HasForeignKey(x => x.SongId);

        builder
            .HasOne(x => x.Tuning)
            .WithMany(x => x.Tabs)
            .HasForeignKey(x => x.TuningId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .Property(x => x.Name)
            .IsRequired();
    }
}