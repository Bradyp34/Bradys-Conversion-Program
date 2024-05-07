using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensCoat
{
    public long CoatId { get; set; }

    public string Coat { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
