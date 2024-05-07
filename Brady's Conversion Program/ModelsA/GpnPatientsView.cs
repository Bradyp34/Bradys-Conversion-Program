using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnPatientsView
{
    public long PatientId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public long? LocationId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? BirthYear { get; set; }

    public string? Gender { get; set; }
}
