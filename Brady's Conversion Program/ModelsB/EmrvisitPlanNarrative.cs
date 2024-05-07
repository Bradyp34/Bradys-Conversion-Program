using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitPlanNarrative
{
    public int EmrvisitPlanNarrativesId { get; set; }

    public int? VisitId { get; set; }

    public int PtId { get; set; }

    public int? VisitDoctorId { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? VisitDiagCodePoolId { get; set; }

    public string? Snomedcode { get; set; }

    public string? Icd10code { get; set; }

    public string? Icd9code { get; set; }

    public string? NarrativeHeader { get; set; }

    public string? NarrativeText { get; set; }

    public string? NarrativeType { get; set; }

    public int DisplayOrder { get; set; }

    public string? InsertGuid { get; set; }
}
