using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class ExamCondition
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? Condition { get; set; }

    public string? Eye { get; set; }

    public string? ConditionValue { get; set; }

    public string? Comment { get; set; }

    public string? Active { get; set; }
}
