using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToLabFrameMaterial
{
    public long Uid { get; set; }

    public long LabId { get; set; }

    public long MaterialId { get; set; }

    public bool? Active { get; set; }
}
