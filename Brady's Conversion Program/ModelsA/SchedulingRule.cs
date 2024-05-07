using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingRule
{
    public int RuleId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long ResourceId { get; set; }

    public bool Active { get; set; }
}
