using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetAppointmentAndRecallTypesView
{
    public long AppointmentTypeId { get; set; }

    public string AppointmentTypeCode { get; set; } = null!;

    public string AppointmentTypeDescription { get; set; } = null!;

    public int? DefaultDuration { get; set; }

    public bool? Active { get; set; }

    public bool IsAppointmentType { get; set; }

    public bool IsRecallType { get; set; }

    public long StaffLocationId { get; set; }

    public string StaffLocationName { get; set; } = null!;

    public bool? CanSchedule { get; set; }

    public bool PatientRequired { get; set; }

    public bool IsExamType { get; set; }

    public bool? DefaultAppointmentType { get; set; }

    public string IsGroup { get; set; } = null!;

    public bool? WebSchedulingType { get; set; }
}
