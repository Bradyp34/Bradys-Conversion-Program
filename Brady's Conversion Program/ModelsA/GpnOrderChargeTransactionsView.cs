using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnOrderChargeTransactionsView
{
    public long ChargeTransactionId { get; set; }

    public long OrderChargeId { get; set; }

    public int ChargeTransactionSequence { get; set; }

    public int ChargeTransactionTypeId { get; set; }

    public int ChargeTransactionCodeId { get; set; }

    public decimal ChargeTransactionAmount { get; set; }

    public string? ChargeTransactionReference { get; set; }

    public string? ChargeTransactionBatchNumber { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? ChargeTransactionCreatedDate { get; set; }

    public DateTime? ChargeTransactionModifiedDate { get; set; }

    public long PatientInsuranceId { get; set; }
}
