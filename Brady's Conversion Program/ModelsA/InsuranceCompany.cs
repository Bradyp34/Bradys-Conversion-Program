using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsuranceCompany
{
    public long InsuranceId { get; set; }

    public string? InsuranceCode { get; set; }

    public string? InsuranceName { get; set; }

    public long? AddressId { get; set; }

    public string? PayorId { get; set; }
}
