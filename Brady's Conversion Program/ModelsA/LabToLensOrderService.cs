using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToLensOrderService
{
    public long LabToLensOrderServiceId { get; set; }

    public long LabId { get; set; }

    public int ServiceId { get; set; }

    public bool? Active { get; set; }
}
