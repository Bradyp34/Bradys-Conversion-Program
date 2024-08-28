using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class ProcDiagPool
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? VisitProcCodePoolId { get; set; }

    public string? VisitDiagCodePoolId { get; set; }

    public string? RequestedProcedureId { get; set; }

    public string? Active { get; set; }
}
