using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitPlanNarrativeFragment
{
    public int VisitPlanNarrativeFragmentId { get; set; }

    public int EmrvisitPlanNarrativesId { get; set; }

    public int? FastPlanNarrativeFragmentId { get; set; }

    public string NarrativeType { get; set; } = null!;

    public string NarrativeText { get; set; } = null!;

    public string? Snomedcode { get; set; }

    public string? ShortHand { get; set; }

    public int DisplayOrder { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedEmpId { get; set; }

    public DateTime? LastModified { get; set; }

    public int? LastModifiedEmpId { get; set; }
}
