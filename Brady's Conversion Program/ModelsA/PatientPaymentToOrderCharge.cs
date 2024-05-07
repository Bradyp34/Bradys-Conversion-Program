using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PatientPaymentToOrderCharge
{
    public long PatientPaymentToChargeId { get; set; }

    public long? TransactionId { get; set; }

    public long PatientPaymentId { get; set; }

    public long? OrderChargeId { get; set; }

    public decimal? AmountAppliedToCharge { get; set; }

    public virtual PatientPayment PatientPayment { get; set; } = null!;
}
