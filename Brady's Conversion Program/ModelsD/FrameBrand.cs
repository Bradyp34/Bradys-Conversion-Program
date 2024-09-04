using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameBrand
{
    public long Id { get; set; }

    public string? OldBrandId { get; set; }

    public string? BrandName { get; set; }

    public string? LocationId { get; set; }

    public string? Active { get; set; }
}
