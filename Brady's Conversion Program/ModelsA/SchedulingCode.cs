using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingCode
{
    public long SchedulingCodeId { get; set; }

    public string Code { get; set; } = null!;

    public int TypeId { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public bool IsDefaultCode { get; set; }

    public bool IsNoShow { get; set; }
}
