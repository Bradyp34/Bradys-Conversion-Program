using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntEthnicity
{
    public short EthnicityId { get; set; }

    public string Ethnicity { get; set; } = null!;

    public bool? IsActive { get; set; }
}
