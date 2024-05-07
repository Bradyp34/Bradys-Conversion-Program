using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EyeCareProInformation
{
    public string EyeCareProLoginName { get; set; } = null!;

    public string EyeCareProPassword { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string VersionNumber { get; set; } = null!;

    public DateTime? ApplicationLastUpdatedDateTime { get; set; }
}
