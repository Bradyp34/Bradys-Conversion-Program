using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetRecallsView
{
    public long RecallId { get; set; }

    public DateOnly? RecallDate { get; set; }

    public int AppointmentTypeId { get; set; }

    public string? RecallReason { get; set; }

    public bool Active { get; set; }

    public int Satisfied { get; set; }

    public DateTime? RecallCreatedDateTime { get; set; }

    public DateTime? RecallModifiedDateTime { get; set; }

    public int ResourceId { get; set; }

    public string RecallProvider { get; set; } = null!;

    public int SchedulingLocationId { get; set; }

    public string RecallLocation { get; set; } = null!;

    public long PatientId { get; set; }

    public int StaffLocationId { get; set; }
}
