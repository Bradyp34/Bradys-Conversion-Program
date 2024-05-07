using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitExamCondition
{
    public int ExamConditionId { get; set; }

    public int? VisitId { get; set; }

    public int PtId { get; set; }

    public DateTime Dosdate { get; set; }

    public int? LocationId { get; set; }

    public string? Laterality { get; set; }

    public int? ConditionId { get; set; }

    public string? Condition { get; set; }

    public string? Comment { get; set; }

    public string? Snomed { get; set; }
}
