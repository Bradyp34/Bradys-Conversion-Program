using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwSelectedTreatmentsOfOrder
{
    public long VwselectedTreatmentsId { get; set; }

    public long OrderId { get; set; }

    public long TreatmentId { get; set; }

    public long LocationId { get; set; }
}
