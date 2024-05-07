using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientStatementInformation
{
    public long PatientStatementId { get; set; }

    public long PatientId { get; set; }

    public DateTime? StatementDateTime { get; set; }

    public string StatementFilePath { get; set; } = null!;

    public bool InvalidStatement { get; set; }

    public string InvalidStatementMessage { get; set; } = null!;
}
