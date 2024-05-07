using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrfastPlan
{
    public int FastPlanId { get; set; }

    public string? FastPlanName { get; set; }

    public string? FastPlanDiagComments { get; set; }

    public string? FastPlanPtInstruc { get; set; }

    public string? FastPlanActions { get; set; }

    public string? FastPlanDiscussedWithPt { get; set; }

    public string? FastPlanDiscussion { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public int? FastPlanEmpId { get; set; }

    public int? FastPlanPtEducationId { get; set; }

    public short? Prioritize { get; set; }

    public string? FastPlanRtowhen { get; set; }

    public string? InsertGuid { get; set; }

    public string? SxProcPerformed { get; set; }
}
