using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameMountsView
{
    public int FrameMountId { get; set; }

    public string FrameMount { get; set; } = null!;

    public bool IsActive { get; set; }

    public long LocationId { get; set; }
}
