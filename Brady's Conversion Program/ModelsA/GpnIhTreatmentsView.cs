using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnIhTreatmentsView
{
    public long IhTreatmentId { get; set; }

    public string IhTreatmentCode { get; set; } = null!;

    public string IhTreatmentDescription { get; set; } = null!;
}
