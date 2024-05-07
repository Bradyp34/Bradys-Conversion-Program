using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitProcCodePoolDiag
{
    public int VisitProcCodePoolDiagId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public int? ControlId { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? VisitProcCodePoolId { get; set; }

    public int? VisitDiagCodePoolId { get; set; }

    public int? RequestedProcedureId { get; set; }

    public string? InsertGuid { get; set; }
}
