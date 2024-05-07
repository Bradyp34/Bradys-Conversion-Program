using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensTint
{
    public int TintId { get; set; }

    public string Tint { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
