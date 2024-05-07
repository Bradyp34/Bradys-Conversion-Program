using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
