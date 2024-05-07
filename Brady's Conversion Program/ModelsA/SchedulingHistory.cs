using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingHistory
{
    public long SchedulingHistoryId { get; set; }

    public int? StaffId { get; set; }

    public long EventSponsorId { get; set; }

    public string? EventCategory { get; set; }

    public string? EventType { get; set; }

    public string? EventDetails { get; set; }

    public DateTime? EventDateTime { get; set; }

    public string? Notes { get; set; }
}
