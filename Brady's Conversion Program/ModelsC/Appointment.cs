using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Appointment
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public string? OldApptId { get; set; }

    public string? ClientSoftwareApptId { get; set; }

    public string? ApptLocationId { get; set; }

    public string? ApptStatus { get; set; }

    public string? ApptStartTime { get; set; }

    public string? ApptNotes { get; set; }

    public string? ApptProviderEmpId { get; set; }

    public string? ApptHl7status { get; set; }

    public string? IntakeStatus { get; set; }

    public string? ApptType { get; set; }

    public string? ApptReason { get; set; }

    public string? Active { get; set; }
}
