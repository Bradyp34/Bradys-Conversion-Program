using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationUvLensCoatInformation
{
    public int LocationUvLensId { get; set; }

    public long LabToLensCoatId { get; set; }

    public long LocationId { get; set; }

    public int CptId { get; set; }

    public decimal Charge { get; set; }
}
