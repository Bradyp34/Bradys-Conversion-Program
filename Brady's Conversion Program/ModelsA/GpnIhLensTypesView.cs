using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnIhLensTypesView
{
    public long IhLensTypeId { get; set; }

    public string IhLensTypeCode { get; set; } = null!;

    public string IhLensTypeDescription { get; set; } = null!;
}
