using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationLensTintInformation
{
    public int LocationLensTintId { get; set; }

    public long LabToLensTintId { get; set; }

    public long LocationId { get; set; }

    public int CptId { get; set; }

    public decimal Charge { get; set; }
}
