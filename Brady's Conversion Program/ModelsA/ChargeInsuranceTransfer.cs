using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeInsuranceTransfer
{
    public long ChargeInsuranceTransferId { get; set; }

    public long OrderChargeId { get; set; }

    public long OldInsuranceId { get; set; }

    public long NewInsuranceId { get; set; }

    public decimal AmountTransfered { get; set; }

    public bool GenerateClaim { get; set; }

    public bool AcceptAssignment { get; set; }
}
