using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensColorsView
{
    public long ColorId { get; set; }

    public string Color { get; set; } = null!;

    public string? ColorDescription { get; set; }

    public string? ColorCode { get; set; }
}
