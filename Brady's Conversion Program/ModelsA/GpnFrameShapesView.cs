using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameShapesView
{
    public int FrameShapeId { get; set; }

    public string FrameShape { get; set; } = null!;

    public bool IsActive { get; set; }

    public long? LocationId { get; set; }
}
