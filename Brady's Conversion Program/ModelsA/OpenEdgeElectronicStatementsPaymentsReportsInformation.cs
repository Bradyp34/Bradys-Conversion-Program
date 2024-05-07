using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeElectronicStatementsPaymentsReportsInformation
{
    public long Id { get; set; }

    public long ElectronicPaymentId { get; set; }

    public DateTime ReportDateTime { get; set; }

    public string ReportFilePath { get; set; } = null!;
}
