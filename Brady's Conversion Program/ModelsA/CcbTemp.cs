using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CcbTemp
{
    public string PatientId { get; set; } = null!;

    public long? OrderId { get; set; }

    public long? OrderChargeId { get; set; }

    public int? InsuranceId { get; set; }
}
