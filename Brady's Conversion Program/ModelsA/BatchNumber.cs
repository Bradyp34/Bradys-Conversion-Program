using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class BatchNumber
{
    public int BatchNumberId { get; set; }

    public string FfpmUserName { get; set; } = null!;

    public string? BatchNumber1 { get; set; }

    public DateOnly BatchDate { get; set; }

    public string Type { get; set; } = null!;
}
