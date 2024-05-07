using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensStylesView
{
    public int LensStyleId { get; set; }

    public string LensStyleName { get; set; } = null!;

    public string? LensStyleCode { get; set; }
}
