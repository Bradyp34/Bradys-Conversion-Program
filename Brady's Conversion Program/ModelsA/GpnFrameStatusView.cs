using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameStatusView
{
    public int FrameStatusId { get; set; }

    public string FrameStatus { get; set; } = null!;

    public string? FrameStatusLabCode { get; set; }
}
