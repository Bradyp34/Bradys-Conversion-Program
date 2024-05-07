using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingAppointmentType
{
    public long AppointmentTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? DefaultDuration { get; set; }

    public bool? Active { get; set; }

    public bool? CanSchedule { get; set; }

    public bool? CanPrint { get; set; }

    public string? BackgroundColor { get; set; }

    public string? ForegroundColor { get; set; }

    public string? ConflictColor { get; set; }

    public int LocationId { get; set; }

    public bool PatientRequired { get; set; }

    public string Notes { get; set; } = null!;

    public bool IsAppointmentType { get; set; }

    public bool IsRecallType { get; set; }

    public bool? DefaultAppointmentType { get; set; }

    public bool IsExamType { get; set; }

    public string? WebAppointmentColor { get; set; }
}
