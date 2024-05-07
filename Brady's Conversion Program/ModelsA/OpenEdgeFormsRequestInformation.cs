using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeFormsRequestInformation
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public long PatientId { get; set; }

    public int FormId { get; set; }

    public long AppointmentId { get; set; }

    public int SchedulingResourceId { get; set; }

    public DateTime? TriggerDateTime { get; set; }

    public DateTime RecordAddedDateTime { get; set; }

    public int StaffLocationId { get; set; }

    public int StaffId { get; set; }

    public bool Active { get; set; }

    public bool? Processed { get; set; }

    public DateTime? ProcessedDateTime { get; set; }
}
