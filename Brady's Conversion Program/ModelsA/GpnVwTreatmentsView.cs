using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnVwTreatmentsView
{
    public long VwTreatmentId { get; set; }

    public string VwTreatmentCode { get; set; } = null!;

    public string VwTreatmentDescription { get; set; } = null!;
}
