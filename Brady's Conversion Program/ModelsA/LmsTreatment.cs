using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsTreatment
{
    public long TreatmentId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public int? MiscChargeId { get; set; }

    public int LmsLabId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsUpdated { get; set; }
}
