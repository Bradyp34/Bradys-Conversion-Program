using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxType
{
    public int TaxTypeId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public long? LocationId { get; set; }
}
