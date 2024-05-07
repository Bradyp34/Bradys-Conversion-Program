using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FinalizeClaimAndDepositSlipReportDetail
{
    public long Id { get; set; }

    public int StaffId { get; set; }

    public DateTime? ReportDateTime { get; set; }

    public bool? IsFinalizeReport { get; set; }

    public string ReportFilePath { get; set; } = null!;

    public string DepositSlipFilePath { get; set; } = null!;
}
