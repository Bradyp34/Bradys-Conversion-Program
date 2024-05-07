using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingAppointment
{
    public long AppointmentId { get; set; }

    public long PatientId { get; set; }

    public long AppointmentTypeId { get; set; }

    public long ResourceId { get; set; }

    public int BillingLocationId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Duration { get; set; }

    public bool? AllDay { get; set; }

    public int? Status { get; set; }

    public DateTime? CheckInDateTime { get; set; }

    public DateTime? TakeBackDateTime { get; set; }

    public DateTime? CheckOutDateTime { get; set; }

    public DateTime DateTimeCreated { get; set; }

    public DateTime? DateTimeUpdated { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public long? PriorAppointmentId { get; set; }

    public long? LinkedAppointmentId { get; set; }

    public int? SchedulingCodeId { get; set; }

    public string? SchedulingCodeNotes { get; set; }

    public int LocationId { get; set; }

    public bool Confirmed { get; set; }

    public int Sequence { get; set; }

    public long? RecallId { get; set; }

    public long? WaitingListId { get; set; }

    public long RequestId { get; set; }
}
