using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLensCoatsView
{
    public long LensCoatId { get; set; }

    public string LensCoat { get; set; } = null!;

    public string? Description { get; set; }

    public string? LensCoatCode { get; set; }
}
