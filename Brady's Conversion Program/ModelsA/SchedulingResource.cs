using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingResource
{
    public long ResourceId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public long? SpecialtyId { get; set; }

    public int? Color { get; set; }

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public string? EmailId { get; set; }
}
