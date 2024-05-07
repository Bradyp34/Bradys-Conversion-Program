using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DiagnosisCodesNew
{
    public long DiagnosisCodeId { get; set; }

    public string DiagnosisCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long LocationId { get; set; }

    public long? SortOrder { get; set; }

    public bool Active { get; set; }
}
