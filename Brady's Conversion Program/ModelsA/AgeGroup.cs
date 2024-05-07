using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class AgeGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string GroupDescription { get; set; } = null!;

    public int SortOrder { get; set; }
}
