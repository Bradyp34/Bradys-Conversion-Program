using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InventoryAuditReport
{
    public int AuditReportId { get; set; }

    public int AuditId { get; set; }

    public string AuditReportName { get; set; } = null!;
}
