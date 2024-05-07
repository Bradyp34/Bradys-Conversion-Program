using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwLabAccountInfo
{
    public int LabId { get; set; }

    public int SupplierId { get; set; }

    public long LocationId { get; set; }

    public string LabUserName { get; set; } = null!;

    public string LabPassword { get; set; } = null!;

    public string? BillAccount { get; set; }

    public string? ShipAccount { get; set; }
}
