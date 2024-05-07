using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrappt
{
    public int ApptId { get; set; }

    public string? ClientSoftwareApptId { get; set; }

    public int? ApptPtId { get; set; }

    public int? ApptLocationId { get; set; }

    public int? ApptStatus { get; set; }

    public DateTime? ApptStartTime { get; set; }

    public string? ApptNotes { get; set; }

    public int? ApptProviderEmpId { get; set; }

    public string? InsertGuid { get; set; }

    public string? ApptHl7status { get; set; }

    public int? IntakeStatus { get; set; }

    public string? ApptType { get; set; }

    public string? ApptReason { get; set; }

    public string? IntakeSubmissionGuid { get; set; }

    public int? IntakeEmrDataStatus { get; set; }

    public int? IntakePatientDocumentStatus { get; set; }

    public int? IntakePmDataStatus { get; set; }

    public int? IntakeLastSavedDocumentIndex { get; set; }

    public int? IntakeSummaryStatus { get; set; }
}
