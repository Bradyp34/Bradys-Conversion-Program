using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameCollectionView
{
    public long FrameCollectionId { get; set; }

    public string FrameCollectionName { get; set; } = null!;

    public bool IsActive { get; set; }

    public long LocationId { get; set; }
}
