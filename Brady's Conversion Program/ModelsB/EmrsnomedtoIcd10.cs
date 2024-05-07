using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrsnomedtoIcd10
{
    public int TableId { get; set; }

    public string? ReferencedComponentId { get; set; }

    public int? MapGroup { get; set; }

    public int? MapPriority { get; set; }

    public string? MapAdvice { get; set; }

    public string? MapTarget { get; set; }
}
