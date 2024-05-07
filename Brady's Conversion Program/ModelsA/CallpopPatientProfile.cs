using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CallpopPatientProfile
{
    public long Id { get; set; }

    public string AccountNumber { get; set; } = null!;

    public int GroupId { get; set; }

    public int StaffLocationId { get; set; }

    public int StaffId { get; set; }

    public DateTime AddedDatetime { get; set; }

    public bool? Processed { get; set; }

    public DateTime? ProcessedDatetime { get; set; }

    public string? ErrorMessage { get; set; }
}
