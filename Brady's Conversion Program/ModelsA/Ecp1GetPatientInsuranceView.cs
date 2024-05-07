using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetPatientInsuranceView
{
    public long PatientInsuranceId { get; set; }

    public long? PatientId { get; set; }

    public string InsCompanyName { get; set; } = null!;

    public string InsCompanyCode { get; set; } = null!;

    public short? Rank { get; set; }
}
