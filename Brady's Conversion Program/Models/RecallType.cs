using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class RecallType
{
    public int Id { get; set; }

    public string? RecallTypeId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? DefaultDuration { get; set; }

    public string? Active { get; set; }

    public string? Notes { get; set; }
}
