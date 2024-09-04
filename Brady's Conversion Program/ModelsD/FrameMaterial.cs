using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameMaterial
{
    public int Id { get; set; }

    public string? OldMaterialId { get; set; }

    public string? MaterialName { get; set; }

    public string? MaterialDescription { get; set; }

    public string? Active { get; set; }

    public string? SortOrder { get; set; }

    public string? LocationId { get; set; }
}
