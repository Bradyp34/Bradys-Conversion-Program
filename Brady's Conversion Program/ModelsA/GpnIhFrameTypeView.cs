using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnIhFrameTypeView
{
    public long IhFrameTypeId { get; set; }

    public string IhFrameTypeCode { get; set; } = null!;

    public string IhFrameTypeDescription { get; set; } = null!;
}
