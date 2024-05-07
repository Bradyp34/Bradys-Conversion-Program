using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameColor
{
    public long FrameColorId { get; set; }

    public string? ColorCode { get; set; }

    public string? ColorDescription { get; set; }

    public bool Active { get; set; }

    public long LocationId { get; set; }
}
