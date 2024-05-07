using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnVwLensDesignView
{
    public long VwLensDesignId { get; set; }

    public string VwLensDesignCode { get; set; } = null!;

    public string VwLensDesignDescription { get; set; } = null!;

    public long VwLensTypeId { get; set; }
}
