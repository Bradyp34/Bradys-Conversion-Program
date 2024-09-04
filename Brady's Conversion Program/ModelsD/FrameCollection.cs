using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameCollection
{
    public int Id { get; set; }

    public string? OldCollectionId { get; set; }

    public string? CollectionName { get; set; }

    public string? Active { get; set; }

    public string? LocationId { get; set; }
}
