using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToLensStyle
{
    public long Uid { get; set; }

    public long LabId { get; set; }

    public int StyleId { get; set; }

    public bool? Active { get; set; }
}
