using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensTintsView
{
    public int LensTintId { get; set; }

    public string LensTint { get; set; } = null!;

    public string? Description { get; set; }

    public string? LensTintCode { get; set; }
}
