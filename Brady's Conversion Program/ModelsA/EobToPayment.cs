using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EobToPayment
{
    public long EobToPaymentsId { get; set; }

    public long EobId { get; set; }

    public long TransactionId { get; set; }

    public DateTime PaymentDateTime { get; set; }

    public string? Batch { get; set; }

    public int? StaffId { get; set; }

    public decimal AmountApplied { get; set; }

    public long InsuranceId { get; set; }
}
