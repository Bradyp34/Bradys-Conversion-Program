using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrdicomModalityCode
{
    public int TableId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public short? Prioritize { get; set; }
}
