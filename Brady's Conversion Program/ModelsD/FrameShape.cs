using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameShape
{
    public int Id { get; set; }

    public string? OldShapeId { get; set; }

    public string? FrameShape1 { get; set; }

    public string? ShapeDescription { get; set; }

    public string? Active { get; set; }

    public string? SortOrder { get; set; }

    public string? LocationId { get; set; }
}
