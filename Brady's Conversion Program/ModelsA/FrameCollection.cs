using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameCollection
{
    public long CollectionId { get; set; }

    public string CollectionName { get; set; } = null!;

    public bool Active { get; set; }

    public long LocationId { get; set; }
}
