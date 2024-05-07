using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmSrvLineAdjustment
{
    public long EdiRemitIndClmSrvLineAdjId { get; set; }

    public long? EdiRemitIndClmSrvLineId { get; set; }

    public string? EdiRemitIndClmSrvLineAdjGrpCode { get; set; }

    public string? EdiRemitIndClmSrvLineAdjGrpCodeDesc { get; set; }

    public string? EdiRemitIndClmSrvLineAdjReasonCode { get; set; }

    public string? EdiRemitIndClmSrvLineAdjReasonDesc { get; set; }

    public string? EdiRemitIndClmSrvLineAdjMonetaryAmt { get; set; }

    public string? EdiRemitIndClmSrvLineAdjMonetaryQty { get; set; }
}
