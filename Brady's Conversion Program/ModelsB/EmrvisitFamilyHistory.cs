using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitFamilyHistory
{
    public int VisitFamilyHistoryId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? Description { get; set; }

    public string? Relation { get; set; }

    public string? Age { get; set; }

    public string? Status { get; set; }

    public string? Code { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public string? Comments { get; set; }
}
