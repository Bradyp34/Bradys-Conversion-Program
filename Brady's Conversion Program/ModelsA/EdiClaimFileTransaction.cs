using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimFileTransaction
{
    public long EdiClaimFileTransactionId { get; set; }

    public long EdiClaimFileId { get; set; }

    public string? EdiClaimFileTransNumber { get; set; }

    public long? EdiClaimFileTransInsCompanyId { get; set; }

    public int? EdiClaimFileTransStatusId { get; set; }

    public string? EdiClaimFileTransStatusDesc { get; set; }

    public string? EdiClaimFileTransBatchNumber { get; set; }

    public string? EdiClaimFileTransTotalAmount { get; set; }

    public int? EdiClaimFileTransChargeCount { get; set; }

    public DateTime? EdiClaimFileTransDate { get; set; }
}
