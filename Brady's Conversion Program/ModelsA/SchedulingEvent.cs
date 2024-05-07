using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingEvent
{
    public long SchedulingEventId { get; set; }

    public long AppointmentId { get; set; }

    public long PatientId { get; set; }

    public long StaffId { get; set; }

    public string EventType { get; set; } = null!;

    public DateTime EventDateTime { get; set; }

    public int? Processed { get; set; }

    public DateTime? ProcessedDateTime { get; set; }
}
