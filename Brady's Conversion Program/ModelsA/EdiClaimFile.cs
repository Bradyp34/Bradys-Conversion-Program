using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimFile
{
    public long EdiClaimFileId { get; set; }

    public DateTime? EdiClaimDateCreated { get; set; }

    public string? EdiClaimBatchNumber { get; set; }

    public int? EdiTotalClaimCount { get; set; }

    public string? EdiTotalClaimAmount { get; set; }

    public string? EdiClaimControlNumber { get; set; }

    public string? EdiClaimInterchangeNumber { get; set; }

    public string? EdiClaimFileContent { get; set; }

    public string? EdiClaimResponseMessage { get; set; }

    public string? EdiClaim999Output { get; set; }

    public string? EdiClaimReceiverIdentifier { get; set; }

    public string? EdiClaim277Response { get; set; }

    public string? EdiClaim277Output { get; set; }

    public string? EdiClaim277AcceptedAmt { get; set; }

    public string? EdiClaim277RejectedAmt { get; set; }

    public int? EdiClaim277AcceptedCount { get; set; }

    public int? EdiClaim277RejectedCount { get; set; }

    public DateTime? EdiClaim277ProcDate { get; set; }

    public DateTime? EdiClaim277RecDate { get; set; }

    public DateTime? EdiClaim277LastUpdated { get; set; }

    public bool? EdiClaimIsFileRejected { get; set; }
}
