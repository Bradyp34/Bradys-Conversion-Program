using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrcodingIcd10
{
    public int TableId { get; set; }

    public string? CodingValue { get; set; }

    public string? CodingParent { get; set; }

    public string? InsertGuid { get; set; }
}
