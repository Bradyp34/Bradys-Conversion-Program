using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DiagnosisCode
{
    public long DiagnosisCodeId { get; set; }

    public string DiagnosisCode1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long LocationId { get; set; }

    public long? SortOrder { get; set; }

    public bool Active { get; set; }

    public bool IsIcd10 { get; set; }

    public string Icd9code { get; set; } = null!;
}
