using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameColorsView
{
    public long FrameColorId { get; set; }

    public string? FrameColor { get; set; }

    public bool IsActive { get; set; }

    public long LocationId { get; set; }
}
