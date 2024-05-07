using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderChargeTaxDetail
{
    public long OrderChargeId { get; set; }

    public int TaxListId { get; set; }

    public decimal TaxPercentage { get; set; }

    public decimal ChargeCost { get; set; }

    public decimal TaxAmount { get; set; }
}
