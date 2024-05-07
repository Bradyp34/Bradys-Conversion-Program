using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsTint
{
    public long TintId { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public int? LabTintId { get; set; }

    public int LmsLabId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsUpdated { get; set; }
}
