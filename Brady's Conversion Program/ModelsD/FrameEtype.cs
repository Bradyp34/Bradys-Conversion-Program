using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameEtype
{
    public int Id { get; set; }

    public string? OldEtypeId { get; set; }

    public string? Etype { get; set; }

    public string? Description { get; set; }

    public string? LabCode { get; set; }

    public string? Active { get; set; }
}
