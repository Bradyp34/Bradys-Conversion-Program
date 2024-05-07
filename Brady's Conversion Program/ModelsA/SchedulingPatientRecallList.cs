using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingPatientRecallList
{
    public long RecallId { get; set; }

    public long PatientId { get; set; }

    public int AppointmentTypeId { get; set; }

    public int ResourceId { get; set; }

    public int BillingLocationId { get; set; }

    public DateOnly RecallListDate { get; set; }

    public string Notes { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public int NumberOfRecallSent { get; set; }

    public DateTime? DateTimeAdded { get; set; }

    public DateTime? DateTimeUpdated { get; set; }
}
