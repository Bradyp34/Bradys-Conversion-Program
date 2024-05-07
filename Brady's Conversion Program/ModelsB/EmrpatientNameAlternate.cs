using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientNameAlternate
{
    public int PatientNameAlternateId { get; set; }

    public int PtId { get; set; }

    public string? PatientNameFirst { get; set; }

    public string? PatientNameMiddle { get; set; }

    public string? PatientNameLast { get; set; }

    public string? PatientNameTypeCode { get; set; }

    public string? InsertGuid { get; set; }

    public string? PatientNameSuffix { get; set; }
}
