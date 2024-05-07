using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MappingGroup
{
    public int MappingGroupId { get; set; }

    public string? GroupName { get; set; }

    public string? GroupDescription { get; set; }

    public bool? Active { get; set; }
}
