using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgHl7Event
{
    public long DmgHl7EventId { get; set; }

    public long DmgPatientId { get; set; }

    public long DmgStaffId { get; set; }

    public string DmgEventType { get; set; } = null!;

    public DateTime DmgEventDateTime { get; set; }

    public int? Processed { get; set; }

    public DateTime? ProcessedDateTime { get; set; }

    public int? FormId { get; set; }
}
