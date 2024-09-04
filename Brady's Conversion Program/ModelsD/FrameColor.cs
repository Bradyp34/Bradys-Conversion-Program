using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameColor
{
    public int Id { get; set; }

    public string? OldFrameColorId { get; set; }

    public string? ColorCode { get; set; }

    public string? ColorDescription { get; set; }

    public string? Active { get; set; }

    public string? LocationId { get; set; }
}
