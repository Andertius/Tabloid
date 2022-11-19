using System;

namespace Tabloid.Domain.DataTransferObjects;

public class JustNameDto : IDto<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
