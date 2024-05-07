using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToUvLensCoat
{
    public long LabToUvLensCoatId { get; set; }

    public long? LabId { get; set; }

    public long? CoatId { get; set; }

    public bool? Active { get; set; }
}
