using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TransactionTotalByOrderChargeTempTable
{
    public long OrderChargeId { get; set; }

    public decimal? Sum { get; set; }

    public string? Responsibility { get; set; }
}
