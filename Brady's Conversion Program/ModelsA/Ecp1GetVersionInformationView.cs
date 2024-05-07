using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetVersionInformationView
{
    public string EcpVersionNumber { get; set; } = null!;

    public string EcpApplicationLastUpdatedDateTime { get; set; } = null!;

    public string FfpmVersionNumber { get; set; } = null!;

    public string FfpmLastUpdatedDateTime { get; set; } = null!;
}
