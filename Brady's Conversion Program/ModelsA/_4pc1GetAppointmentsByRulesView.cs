using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class _4pc1GetAppointmentsByRulesView
{
    public int? RuleId { get; set; }

    public string? RuleName { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? Duration { get; set; }

    public string? AppointmentDescription { get; set; }

    public string? AppointmentSubject { get; set; }

    public long? ResourceId { get; set; }

    public string? Resource { get; set; }

    public int? AppointmentTypeId { get; set; }

    public string? AppointmentType { get; set; }

    public int? SchedulingLocationId { get; set; }

    public string? SchedulingLocation { get; set; }

    public long? StaffLocationId { get; set; }

    public string? StaffLocationName { get; set; }

    public bool? CanSchedule { get; set; }

    public bool? PatientRequired { get; set; }

    public bool? IsExamType { get; set; }

    public bool? WebSchedule { get; set; }

    public string? IsGroup { get; set; }

    public bool? DefaultAppointmentType { get; set; }
}
