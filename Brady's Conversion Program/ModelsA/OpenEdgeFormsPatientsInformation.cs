using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeFormsPatientsInformation
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public long PatientId { get; set; }

    public int GroupId { get; set; }

    public int StaffLocationId { get; set; }

    public int FormId { get; set; }

    public string RequestData { get; set; } = null!;

    public string ResponseData { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public int StaffId { get; set; }

    public bool Active { get; set; }

    public string? InactivatedOperator { get; set; }

    public DateTime? InactivatedDateTime { get; set; }

    public bool? Processed { get; set; }

    public string? ProcessedStaff { get; set; }

    public DateTime? ProcessedDateTime { get; set; }
}
