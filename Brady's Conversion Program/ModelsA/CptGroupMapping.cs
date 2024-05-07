using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CptGroupMapping
{
    public int MappingId { get; set; }

    public int? CptId { get; set; }

    public int? GroupId { get; set; }

    public int? LocationId { get; set; }

    public bool? Active { get; set; }
}
