using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameEtype
{
    public int EtypeId { get; set; }

    public string Etype { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
