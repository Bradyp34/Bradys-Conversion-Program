using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class AccessLog
{
    public string UserCode { get; set; } = null!;

    public DateTime AccessDate { get; set; }

    public string? Area { get; set; }

    public string? Note { get; set; }
}
