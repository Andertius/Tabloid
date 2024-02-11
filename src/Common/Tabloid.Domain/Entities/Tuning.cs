﻿using System;
using System.Collections.Generic;

using Tabloid.Domain.Enums;

namespace Tabloid.Domain.Entities;

public class Tuning : IEntity<Guid>
{
    public Guid Id { get; set; }

    public int StringNumber { get; set; }

    public string Name { get; set; } = null!;

    public string Strings { get; set; } = null!;

    public Instrument Instrument { get; set; }


    public ICollection<Tab>? Tabs { get; set; }
}