using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameTempleStyle
{
    public int TempleId { get; set; }

    public string Temple { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
