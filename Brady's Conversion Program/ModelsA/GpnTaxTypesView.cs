using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnTaxTypesView
{
    public int TaxTypeId { get; set; }

    public string? Code { get; set; }

    public string? TaxTypeDescription { get; set; }

    public long? LocationId { get; set; }

    public bool? IsActive { get; set; }
}
