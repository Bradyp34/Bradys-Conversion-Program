using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnOrderPackageView
{
    public int OrderPackageId { get; set; }

    public string OrderPackage { get; set; } = null!;

    public string? OrderPackageDescription { get; set; }

    public bool OrderStatusActive { get; set; }
}
