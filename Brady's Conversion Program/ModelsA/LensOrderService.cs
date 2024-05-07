using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensOrderService
{
    public int ServiceId { get; set; }

    public string Service { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
