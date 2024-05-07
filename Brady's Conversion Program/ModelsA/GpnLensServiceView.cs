using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensServiceView
{
    public int LensServiceId { get; set; }

    public string LensService { get; set; } = null!;

    public string? Description { get; set; }

    public string? LensTintCode { get; set; }
}
