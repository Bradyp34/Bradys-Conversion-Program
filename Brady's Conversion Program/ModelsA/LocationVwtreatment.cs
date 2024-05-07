using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LocationVwtreatment
{
    public long LocationVwtreatmentId { get; set; }

    public int CptId { get; set; }

    public decimal Charge { get; set; }

    public long LocationId { get; set; }

    public long TreatmentId { get; set; }

    public bool Active { get; set; }
}
