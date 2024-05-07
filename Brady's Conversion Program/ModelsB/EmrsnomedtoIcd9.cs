using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrsnomedtoIcd9
{
    public int TableId { get; set; }

    public string? MapSetId { get; set; }

    public string? MapConceptId { get; set; }

    public int? MapOption { get; set; }

    public int? MapPriority { get; set; }

    public string? MapTargetId { get; set; }

    public string? MapRule { get; set; }

    public string? MapAdvice { get; set; }
}
