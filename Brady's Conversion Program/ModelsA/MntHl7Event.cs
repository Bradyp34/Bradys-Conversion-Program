using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntHl7Event
{
    public long MntHl7EventId { get; set; }

    public string MntEventCategory { get; set; } = null!;

    public long MntEventSponsorId { get; set; }

    public string MntEventType { get; set; } = null!;

    public DateTime MntEventDateTime { get; set; }

    public int? Processed { get; set; }

    public DateTime? ProcessedDateTime { get; set; }
}
