using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxCrossReference
{
    public int TaxCrossReferenceId { get; set; }

    public int? TaxListId { get; set; }

    public int? TaxTypeId { get; set; }

    public decimal? TaxPercentage { get; set; }

    public int? BillingLocationId { get; set; }

    public DateOnly? EffectiveDate { get; set; }
}
