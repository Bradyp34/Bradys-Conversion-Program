using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class StatementPaymentsInformaiton
{
    public long StatementPaymentsId { get; set; }

    public long PatientPaymentId { get; set; }

    public long OrderChargeId { get; set; }

    public long TransactionId { get; set; }

    public decimal AmountAppliedToCharge { get; set; }

    public string Notes { get; set; } = null!;
}
