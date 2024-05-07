using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class BillingLocation1
{
    public int BillingLocationId { get; set; }

    public long LocationId { get; set; }

    public string? BillingLocationName { get; set; }

    public string? BillingLocationCode { get; set; }

    public bool IsActive { get; set; }

    public bool? TaxActive { get; set; }

    public int? TaxProcedure { get; set; }

    public bool SchedulingActive { get; set; }
}
