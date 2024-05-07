using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GenderGroup
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public string GenderDescription { get; set; } = null!;

    public long SortOrder { get; set; }
}
