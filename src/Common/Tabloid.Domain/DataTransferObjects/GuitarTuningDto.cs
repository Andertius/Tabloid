using System;
using System.Collections.Generic;

using Tabloid.Domain.Enums;

namespace Tabloid.Domain.DataTransferObjects;

public class TuningDto : IDto<Guid>
{
    public Guid Id { get; set; }

    public int StringNumber { get; set; }

    public string Name { get; set; } = null!;

    public Instrument Instrument { get; set; }

    public string Strings { get; set; } = null!;


    public ICollection<JustNameDto>? Tabs { get; set; }
}
