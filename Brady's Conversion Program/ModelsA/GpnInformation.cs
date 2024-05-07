using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnInformation
{
    public string GpnLoginName { get; set; } = null!;

    public string GpnLoginPassword { get; set; } = null!;

    public DateTime CreateDate { get; set; }
}
