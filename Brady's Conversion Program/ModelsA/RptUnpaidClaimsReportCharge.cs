using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class RptUnpaidClaimsReportCharge
{
    public long RptUnpaidClmsRptChargeId { get; set; }

    public long RptUnpaidClmsReportId { get; set; }

    public long OrderChargeId { get; set; }

    public bool? IsCompleted { get; set; }

    public string? Remarks { get; set; }
}
