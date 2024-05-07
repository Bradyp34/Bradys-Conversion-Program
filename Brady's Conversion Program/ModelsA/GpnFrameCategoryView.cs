using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameCategoryView
{
    public int FrameCategoryId { get; set; }

    public string FrameCategoryName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public long? LocationId { get; set; }
}
