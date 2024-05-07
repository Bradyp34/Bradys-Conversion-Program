using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emriom
{
    public int Iomid { get; set; }

    public int? RelatedPtId { get; set; }

    public int? RelatedVisitId { get; set; }

    public int? RelatedControlId { get; set; }

    public int? RelatedRecordId { get; set; }

    public int? EmpSent { get; set; }

    public int? EmpTo { get; set; }

    public DateTime? SentTimeStamp { get; set; }

    public short Read { get; set; }

    public DateTime? ReadTimeStamp { get; set; }

    public short Completed { get; set; }

    public DateTime? CompletedTimeStamp { get; set; }

    /// <summary>
    /// Is Null or 0 = Normal, 1=Urgent
    /// </summary>
    public int? Priority { get; set; }

    public string? RegardingText { get; set; }

    public string? MessageText { get; set; }

    public short IsDeleted { get; set; }

    public DateTime? DeletedTimeStamp { get; set; }

    public short ReAssigned { get; set; }

    public DateTime? ReAssignedTimeStamp { get; set; }

    public int? OriginalIomid { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public string? IommessageGuid { get; set; }

    public string? DirectMessageAddress { get; set; }

    public string? DirectGuid { get; set; }

    public int? WebportalMessageId { get; set; }

    public int? RelatedReferralOrderId { get; set; }
}
