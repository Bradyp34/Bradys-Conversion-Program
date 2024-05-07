using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameMount
{
    public int FrameMountId { get; set; }

    public string FrameMount1 { get; set; } = null!;

    public string? MountDescription { get; set; }

    public bool Active { get; set; }

    public long SortOrder { get; set; }

    public long LocationId { get; set; }
}
