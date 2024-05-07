using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnChargeTransactionCodesView
{
    public int TransactionCodeId { get; set; }

    public int? TransactionTypeId { get; set; }

    public string TransactionCode { get; set; } = null!;

    public string TransactionCodeName { get; set; } = null!;

    public string? TransactionCodeDescription { get; set; }

    public long? PaymentTypeId { get; set; }

    public string? CreditOrDebitOrDesc { get; set; }

    public int IsPatientPayment { get; set; }

    public bool TransactionTypeActive { get; set; }

    public int LocationId { get; set; }
}
