using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToLensTint
{
    public long LabToLensTintId { get; set; }

    public long? LabId { get; set; }

    public int? TintId { get; set; }

    public bool? Active { get; set; }
}
