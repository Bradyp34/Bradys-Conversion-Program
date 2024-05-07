using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnIhLensDesignView
{
    public long IhLensDesignId { get; set; }

    public string IhLensDesignCode { get; set; } = null!;

    public string IhLensDesignDescription { get; set; } = null!;

    public int? IhLensTypeId { get; set; }
}
