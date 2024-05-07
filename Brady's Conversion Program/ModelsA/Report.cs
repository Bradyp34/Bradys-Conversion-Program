using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Report
{
    public long ReportId { get; set; }

    public string? DisplayName { get; set; }

    public string ReportPath { get; set; } = null!;

    public int? CategoryId { get; set; }

    public long SortOrder { get; set; }

    public bool? Active { get; set; }

    public long? LocationId { get; set; }

    public string? Parameters { get; set; }
}
