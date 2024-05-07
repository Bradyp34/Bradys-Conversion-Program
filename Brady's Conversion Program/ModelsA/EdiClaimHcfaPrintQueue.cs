using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimHcfaPrintQueue
{
    public long EdiClaimHcfaPrintQueueItemId { get; set; }

    public long? EdiClaimFileTransIndClaimId { get; set; }

    public long? EdiClaimHcfaPrintQuePatId { get; set; }

    public long? EdiClaimHcfaInsCompanyId { get; set; }

    public string? EdiClaimHcfaInsPolicyNum { get; set; }

    public string? EdiClaimHcfaClaimAmt { get; set; }

    public int? EdiClaimHcfaClmChargeCt { get; set; }

    public DateTime? EdiClaimHcfaClmDos { get; set; }

    public int? EdiClaimHcfaPrintQueueItemStatus { get; set; }

    public int? AddedBy { get; set; }

    public int? LastModifiedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? Notes { get; set; }

    public string? EdiClaimHcfaFileContent { get; set; }

    public bool? EdiClaimFileIsPrintJobSuccess { get; set; }
}
