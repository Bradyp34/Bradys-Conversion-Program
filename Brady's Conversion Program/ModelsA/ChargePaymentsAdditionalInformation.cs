using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargePaymentsAdditionalInformation
{
    public long ChargePaymentsAdditionalInformationId { get; set; }

    public long Payment1TransactionId { get; set; }

    public long Payment2TransactionId { get; set; }

    public long Adjustment1TransactionId { get; set; }

    public long Adjustment2TransactionId { get; set; }

    public decimal Allowed { get; set; }

    public decimal Deductable { get; set; }

    public decimal Copay { get; set; }

    public decimal Coinsurance { get; set; }

    public long InsuranceId { get; set; }

    public long Adjustment3TransactionId { get; set; }

    public long Adjustment4TransactionId { get; set; }
}
