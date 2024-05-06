using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public string? AppointmentId { get; set; }

    public string? PatientId { get; set; }

    public string? AppointmentTypeId { get; set; }

    public string? ResourceId { get; set; }

    public string? BillingLocationId { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Duration { get; set; }

    public string? Status { get; set; }

    public string? CheckInDateTime { get; set; }

    public string? TakeBackDateTime { get; set; }

    public string? CheckOutDateTime { get; set; }

    public string? DateTimeCreated { get; set; }

    public string? DateTimeUpdated { get; set; }

    public string? Description { get; set; }

    public string? Notes { get; set; }

    public string? PriorAppointmentId { get; set; }

    public string? LinkedAppointmentId { get; set; }

    public string? SchedulingCodeId { get; set; }

    public string? SchedulingCodeNotes { get; set; }

    public string? Confirmed { get; set; }

    public string? Sequence { get; set; }

    public string? RecallId { get; set; }

    public string? WaitingListId { get; set; }

    public string? RequestId { get; set; }
}
