using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class IntakeConsentForm
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ConsentFormId { get; set; } = null!;

    public int? DisplayOrder { get; set; }
}
