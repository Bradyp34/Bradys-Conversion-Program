using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingPatientWaitingList
{
    public long WaitingListId { get; set; }

    public long PatientId { get; set; }

    public int AppointmentTypeId { get; set; }

    public int ResourceId { get; set; }

    public int BillingLocationId { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public int PriorityId { get; set; }

    public string Notes { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }
}
