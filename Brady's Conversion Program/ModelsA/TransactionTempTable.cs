using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TransactionTempTable
{
    public string? TransactionCode { get; set; }

    public string? Description { get; set; }

    public string? Active { get; set; }

    public int? TransactionType { get; set; }

    public int? CreditDebitDescriptionId { get; set; }
}
