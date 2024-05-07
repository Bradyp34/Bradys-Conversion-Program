using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeTransactionType
{
    public int TransactionTypeId { get; set; }

    public string? TransactionTypeName { get; set; }

    public string? TransactionTypeCode { get; set; }

    public string? TransactionTypeDescription { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ChargeTransactionCode> ChargeTransactionCodes { get; set; } = new List<ChargeTransactionCode>();

    public virtual ICollection<ChargeTransaction> ChargeTransactions { get; set; } = new List<ChargeTransaction>();
}
