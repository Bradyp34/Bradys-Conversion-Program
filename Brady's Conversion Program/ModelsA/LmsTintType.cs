using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsTintType
{
    public long TintTypeId { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public bool? RequiresPercent { get; set; }

    public int? LabTintTypeId { get; set; }

    public int LmsLabId { get; set; }

    public bool? IsUpdated { get; set; }

    public bool? IsActive { get; set; }
}
