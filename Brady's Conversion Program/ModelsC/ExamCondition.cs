using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class ExamCondition
{
    public int Id { get; set; }

    public string? VisitId { get; set; }

    public string? PtId { get; set; }

    public string? Dosdate { get; set; }

    public string? Condition { get; set; }

    public string? Eye { get; set; }

    public string? ConditionValue { get; set; }

    public string? Comment { get; set; }
}
