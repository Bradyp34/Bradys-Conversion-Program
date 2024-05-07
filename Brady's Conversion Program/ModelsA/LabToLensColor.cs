using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToLensColor
{
    public long Uid { get; set; }

    public long? LabId { get; set; }

    public long? ColorId { get; set; }

    public bool? Active { get; set; }
}
