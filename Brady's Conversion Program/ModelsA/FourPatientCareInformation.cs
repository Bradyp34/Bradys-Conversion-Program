using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FourPatientCareInformation
{
    public string _4pcLoginName { get; set; } = null!;

    public string _4pcLoginPassword { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string VersionNumber { get; set; } = null!;

    public DateTime? ApplicationLastUpdatedDateTime { get; set; }
}
