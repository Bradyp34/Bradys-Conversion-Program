using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmreditTracker
{
    public int EditTrackerId { get; set; }

    public int? EmpId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public string? ItemDescription { get; set; }

    public DateTime? TimeStamp { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public short? Emergency { get; set; }

    public string? LinkedFile { get; set; }

    public int? TrackerType { get; set; }

    public DateTime? RequestDate { get; set; }

    public int? RequestDays { get; set; }

    public int? RelatedProviderId { get; set; }

    public string? ActionType { get; set; }

    public string? PreviousData { get; set; }

    public string? AuditHash { get; set; }

    public short? UserTimeZone { get; set; }
}
