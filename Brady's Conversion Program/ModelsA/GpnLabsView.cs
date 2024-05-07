using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLabsView
{
    public long LabId { get; set; }

    public string? LabName { get; set; }

    public long LocationId { get; set; }

    public bool? LabActive { get; set; }

    public int? InHouseVisionWebLab { get; set; }
}
