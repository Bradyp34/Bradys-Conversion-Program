using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitDiagCodePoolStatus
{
    public int VisitDiagCodePoolStatusId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public int? RequestedProcedureId { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? VisitDiagCodePoolId { get; set; }

    public int? Priority { get; set; }

    public int? Severity1 { get; set; }

    public int? Severity2 { get; set; }

    public string? CareEpisode { get; set; }

    public string? CodeIcd10final { get; set; }

    public string? InsertGuid { get; set; }
}
