using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationArLensCoatInformation
{
    public int LocationArLensCoatId { get; set; }

    public long LabToLensCoatId { get; set; }

    public long LocationId { get; set; }

    public int CptId { get; set; }

    public decimal Charge { get; set; }
}
