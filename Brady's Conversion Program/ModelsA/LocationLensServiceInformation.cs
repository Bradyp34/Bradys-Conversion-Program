using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationLensServiceInformation
{
    public int LocationLensServiceId { get; set; }

    public long LabToLensServiceId { get; set; }

    public long LocationId { get; set; }

    public int CptId { get; set; }

    public decimal Charge { get; set; }
}
