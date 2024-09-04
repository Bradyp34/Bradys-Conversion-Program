using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameStatus
{
    public int Id { get; set; }

    public string? OldStatusId { get; set; }

    public string? Description { get; set; }

    public string? LabCode { get; set; }

    public string? Active { get; set; }
}
