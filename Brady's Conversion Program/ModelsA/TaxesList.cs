using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxesList
{
    public int TaxListId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Active { get; set; }

    public long? LocationId { get; set; }

    public int CptId { get; set; }
}
