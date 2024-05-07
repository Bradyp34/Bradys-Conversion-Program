using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxTable
{
    public long TaxId { get; set; }

    public long LocationId { get; set; }

    public int? BillingLocationId { get; set; }

    public long? InsuranceId { get; set; }

    public bool SendToIns { get; set; }

    public decimal TaxPercent { get; set; }

    public DateOnly EffectiveDate { get; set; }

    public long UserId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public bool Active { get; set; }
}
