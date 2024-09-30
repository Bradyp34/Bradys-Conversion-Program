using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class ButtonSetup
{
    public long ButtonId { get; set; }

    public int Button { get; set; }

    public string? Description { get; set; }

    public int? Section { get; set; }

    public bool? Active { get; set; }

    public int? Stage { get; set; }

    public string? Emails { get; set; }

    public bool? Finalized { get; set; }

    public string? SecondTitle { get; set; }
}
