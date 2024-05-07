using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrcontrolId
{
    public int TableId { get; set; }

    public int? ControlId { get; set; }

    public string? ControlType { get; set; }

    public string? ControlNames { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? Xmlname { get; set; }
}
