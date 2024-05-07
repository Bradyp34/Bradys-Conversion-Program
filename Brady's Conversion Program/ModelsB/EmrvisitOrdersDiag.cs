using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitOrdersDiag
{
    public int VisitOrderDiagId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? VisitOrderId { get; set; }

    public int? VisitDiagCodePoolId { get; set; }
}
