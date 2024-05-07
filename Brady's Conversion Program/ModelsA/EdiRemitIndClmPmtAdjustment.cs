using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmPmtAdjustment
{
    public long EdiRemitIndClmAdjId { get; set; }

    public long? EdiRemitIndClmPmtId { get; set; }

    public string? EdiRemitIndClmAdjGrpCode { get; set; }

    public string? EdiRemitIndClmAdjGrpCodeDesc { get; set; }

    public string? EdiRemitIndClmAdjReasonCode { get; set; }

    public string? EdiRemitIndClmAdjReasonDesc { get; set; }

    public string? EdiRemitIndClmAdjMonetaryAmt { get; set; }

    public string? EdiRemitIndClmAdjMonetaryQty { get; set; }
}
