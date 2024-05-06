using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class AppointmentType
{
    public int Id { get; set; }

    public string? AppointmentTypeId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? DefaultDuration { get; set; }

    public string? Active { get; set; }

    public string? CanSchedule { get; set; }

    public string? PatientRequired { get; set; }

    public string? Notes { get; set; }

    public string? IsExamType { get; set; }
}
