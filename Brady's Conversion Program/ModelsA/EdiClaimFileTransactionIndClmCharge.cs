using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiClaimFileTransactionIndClmCharge
{
    public long EdiClaimFileTransIndClmChargeId { get; set; }

    public long? EdiClaimFileId { get; set; }

    public long? EdiClaimFileTransId { get; set; }

    public long? EdiClaimFileTransIndClmId { get; set; }

    public long? EdiClaimFileTransIndClmOrderChargeId { get; set; }

    public long? EdiClaimFileTransIndClmEventId { get; set; }

    public long? EdiClaimFileTransIndClmPatInsId { get; set; }

    public short? EdiClaimFileTransIndClmPatInsRank { get; set; }

    public int? EdiClaimFileTransIndClmChgStatusId { get; set; }

    public string? EdiClaimFileTransIndClmChgStatusDesc { get; set; }

    public string? EdiClaimChargeResponse { get; set; }
}
