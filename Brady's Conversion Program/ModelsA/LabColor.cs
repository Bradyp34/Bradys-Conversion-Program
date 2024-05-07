using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabColor
{
    public long ColorId { get; set; }

    public string Color { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
