using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class SchedCode
{
    public int Id { get; set; }

    public string? SchedulingCodeId { get; set; }

    public string? Code { get; set; }

    public string? TypeId { get; set; }

    public string? Description { get; set; }

    public string? Active { get; set; }

    public string? IsNoShow { get; set; }
}
