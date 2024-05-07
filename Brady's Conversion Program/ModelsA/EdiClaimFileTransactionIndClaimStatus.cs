using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimFileTransactionIndClaimStatus
{
    public long EdiClaimFileTransactionIndClaimStatusId { get; set; }

    public long EdiClaimFileTransIndClaimId { get; set; }

    public string? EdiClaimFileTransIndClmLatestStatus { get; set; }

    public DateTime? EdiClaimFileTransIndClmLastUpdated { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecId { get; set; }

    public DateTime? EdiClaimFileTransIndClmStatusRecCreated { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecDatasource { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecMsgLevel { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecMsg { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecMsg2 { get; set; }

    public string? EdiClaimFileTransIndClmStatusRecStatus { get; set; }

    public bool? IsActive { get; set; }
}
