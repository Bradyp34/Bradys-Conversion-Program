using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntInsuranceType
{
    public short InsuranceTypeId { get; set; }

    public string InsuranceTypeName { get; set; } = null!;

    public string? InsuranceTypeCode { get; set; }

    public bool IsActive { get; set; }
}
