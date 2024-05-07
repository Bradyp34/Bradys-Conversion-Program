using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnPatientVisionInsuranceView
{
    public long PatientInsuranceId { get; set; }

    public long? PatientId { get; set; }

    public short? InsuranceRank { get; set; }

    public string? PolicyNumber { get; set; }

    public bool? IsPolicyActive { get; set; }

    public DateTime? PolicyStartDate { get; set; }

    public DateOnly? PolicyEndDate { get; set; }

    public int? InsCompanyId { get; set; }
}
