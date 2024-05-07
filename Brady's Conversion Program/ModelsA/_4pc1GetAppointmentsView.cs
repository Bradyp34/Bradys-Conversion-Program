using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class _4pc1GetAppointmentsView
{
    public long AppointmentId { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppointmentTime { get; set; }

    public int AppointmentLength { get; set; }

    public string? AppointmentReason { get; set; }

    public long AppointmentTypeId { get; set; }

    public string AppointmentType { get; set; } = null!;

    public string? AppointmentStatus { get; set; }

    public long ResourceId { get; set; }

    public string AppointmentProvider { get; set; } = null!;

    public int SchedulingLocationId { get; set; }

    public string? AppointmentLocation { get; set; }

    public DateTime AppointmentCreatedDate { get; set; }

    public DateTime? AppointmentModifiedDate { get; set; }

    public long PatientId { get; set; }

    public bool AppointmentConfirmed { get; set; }

    public long? PriorAppointmentId { get; set; }

    public int StaffLocationId { get; set; }

    public bool? PatientShowedUp { get; set; }

    public bool? IsNoShow { get; set; }

    public long _4pcAppointmentKey { get; set; }
}
