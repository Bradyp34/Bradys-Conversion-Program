using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnChargeTransactionTypesView
{
    public int TransactionTypeId { get; set; }

    public string? TransactionType { get; set; }

    public string? TransactionTypeDescripton { get; set; }

    public bool TransactionTypeActive { get; set; }
}
