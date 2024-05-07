using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrfastPlanNarrativeFragment
{
    public int FastPlanNarrativeFragmentId { get; set; }

    public int FastPlanId { get; set; }

    public string NarrativeType { get; set; } = null!;

    public string NarrativeText { get; set; } = null!;

    public string? Snomedcode { get; set; }

    public string? ShortHand { get; set; }

    public int DisplayOrder { get; set; }
}
