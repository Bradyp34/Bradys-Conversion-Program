using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeTransactionCode
{
    public int TransactionCodeId { get; set; }

    public int? TransactionTypeId { get; set; }

    public string TransactionCodeName { get; set; } = null!;

    public string TransactionCodeCd { get; set; } = null!;

    public string? TransactionCodeDescription { get; set; }

    public bool IsActive { get; set; }

    public int LocationId { get; set; }

    public long? PaymentTypeId { get; set; }

    public int CreditDebitDescriptionId { get; set; }

    public int CategoryId { get; set; }

    public bool IsPatientPayment { get; set; }

    public int ResponsibilityId { get; set; }

    public virtual ICollection<ChargeTransaction> ChargeTransactions { get; set; } = new List<ChargeTransaction>();

    public virtual ChargeTransactionType? TransactionType { get; set; }
}
