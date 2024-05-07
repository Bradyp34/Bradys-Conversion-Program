using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameMaterialView
{
    public int FrameMaterialId { get; set; }

    public string FrameColor { get; set; } = null!;

    public bool IsActive { get; set; }

    public long LocationId { get; set; }
}
