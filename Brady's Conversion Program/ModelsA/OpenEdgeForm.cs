using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeForm
{
    public int FormId { get; set; }

    public int GroupId { get; set; }

    public string FormName { get; set; } = null!;

    public string OpenedgeFormTypeId { get; set; } = null!;

    public bool RequestFormWithExistingData { get; set; }

    public bool Active { get; set; }

    public bool IsConsentForm { get; set; }

    public string ConsentText { get; set; } = null!;

    public int FormTypeId { get; set; }
}
