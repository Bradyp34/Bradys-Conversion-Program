using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameMaterial
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public string? MaterialDescription { get; set; }

    public bool Active { get; set; }

    public long SortOrder { get; set; }

    public long LocationId { get; set; }
}
