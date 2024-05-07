using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitFollowUpPayment
{
    public long EdiRemitFlwUpPmtId { get; set; }

    public long EdiRemitIndClmPmtSrvLineId { get; set; }

    public string? EdiRemitFlwUpReason { get; set; }

    public DateTime? EdiRemitFlwUpAddedDate { get; set; }

    public int? EdiRemitFlwUpAddedBy { get; set; }

    public string? EdiRemitFlwUpNotes { get; set; }

    public short? EdiRemitFlwUpStatusId { get; set; }

    public int? EdiRemitFlwUpModifiedBy { get; set; }

    public DateTime? EdiRemitFlwUpModifedDate { get; set; }

    public bool? EdiRemitFlwUpSentFromSys { get; set; }

    public string? EdiRemitFlwUpBatchNum { get; set; }

    public string? EdiRemitFlwUpPmtCode { get; set; }

    public string? EdiRemitFlwUpAdjCode { get; set; }
}
