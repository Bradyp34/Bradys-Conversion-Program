using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimFileTransactionIndClaim
{
    public long EdiClaimFileTransIndClaimId { get; set; }

    public long? EdiClaimTransactionId { get; set; }

    public long? EdiClaimFileId { get; set; }

    public string? EdiClaimTransIndClmCtrllNum { get; set; }

    public long? EdiClaimTransIndClmPatId { get; set; }

    public string? EdiClaimTransIndClmBatchNum { get; set; }

    public string? EdiClaimTransIndClmTotalAmt { get; set; }

    public int? EdiClaimTransIndClmChargeCount { get; set; }

    public DateTime? EdiClaimTransIndClmDate { get; set; }

    public int? EdiClaimTransIndClmStatus { get; set; }

    public string? EdiClaimTransIndClmStatusDesc { get; set; }

    public string? EdiClaimTransIndClmPayerLatestStatus { get; set; }

    public bool? EdiClaimTransIndClmInfFlag { get; set; }

    public DateTime? EdiClaimTransIndClmLastUpdate { get; set; }
}
