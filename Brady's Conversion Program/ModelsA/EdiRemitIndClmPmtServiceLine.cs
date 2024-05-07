using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmPmtServiceLine
{
    public long EdiRemitIndClmPmtSrvLineId { get; set; }

    public long? EdiRemitIndClmPmtSrvLineClmPmtId { get; set; }

    public string EdiRemitIndClmPmtSrvLineChargeId { get; set; } = null!;

    public string? EdiRemitIndClmPmtSrvLineEventId { get; set; }

    public string? EdiRemitIndClmPmtSrvLineIdentifier { get; set; }

    public string? EdiRemitIndClmPmtSrvLineProcCode { get; set; }

    public string? EdiRemitIndClmPmtSrvLineMd1 { get; set; }

    public string? EdiRemitIndClmPmtSrvLineMd2 { get; set; }

    public string? EdiRemitIndClmPmtSrvLineMd3 { get; set; }

    public string? EdiRemitIndClmPmtSrvLineMd4 { get; set; }

    public string? EdiRemitIndClmPmtSrvLineBilledAmt { get; set; }

    public string? EdiRemitIndClmPmtSrvLineAlwdAmt { get; set; }

    public string? EdiRemitIndClmPmtSrvLinePaidAmt { get; set; }

    public DateTime? EdiRemitIndClmPmtSrvLineDos { get; set; }

    public bool? EdiRemitIndClmPmtSrvLineIsFlwUp { get; set; }

    public bool? EdiRemitIndClmPmtSrvLineIsPmtPosted { get; set; }
}
