using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class PlanNarrative
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? VisitDoctorId { get; set; }

    public string? VisitDiagCodePoolId { get; set; }

    public string? Snomedcode { get; set; }

    public string? Icd10code { get; set; }

    public string? Icd9code { get; set; }

    public string? NarrativeHeader { get; set; }

    public string? NarrativeText { get; set; }

    public string? NarrativeType { get; set; }

    public string? DisplayOrder { get; set; }

    public string? Active { get; set; }
}
