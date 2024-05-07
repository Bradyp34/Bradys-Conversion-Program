using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GeneralId
{
    public int GeneralId1 { get; set; }

    public string? Category { get; set; }

    public string DisplayValue { get; set; } = null!;

    public string? Description { get; set; }

    public int SortOrder { get; set; }

    public bool Active { get; set; }
}
