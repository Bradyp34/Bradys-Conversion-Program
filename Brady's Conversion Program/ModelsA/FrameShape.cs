using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameShape
{
    public int ShapeId { get; set; }

    public string FrameShape1 { get; set; } = null!;

    public string? ShapeDescription { get; set; }

    public bool Active { get; set; }

    public long SortOrder { get; set; }

    public long? LocationId { get; set; }
}
