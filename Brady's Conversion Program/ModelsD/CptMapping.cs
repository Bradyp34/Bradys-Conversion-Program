using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class CptMapping
{
    public int Id { get; set; }

    public string? MappingId { get; set; }

    public string? CptId { get; set; }

    public string? GroupId { get; set; }

    public string? LocationId { get; set; }

    public string? Active { get; set; }
}
