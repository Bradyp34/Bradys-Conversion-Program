using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensMaterialsView
{
    public long LensMaterialId { get; set; }

    public string LensMaterial { get; set; } = null!;

    public string? LensMaterialCode { get; set; }

    public string? LensMaterialDescription { get; set; }

    public decimal? LensMaterialInde { get; set; }
}
