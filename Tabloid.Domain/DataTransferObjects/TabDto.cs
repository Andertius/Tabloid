﻿using System;

namespace Tabloid.Domain.DataTransferObjects;

public class TabDto : IDto<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Link { get; set; }

    public double? Difficulty { get; set; }

    public TuningDto? Tuning { get; set; }

    public SongDto? Song { get; set; }
}
