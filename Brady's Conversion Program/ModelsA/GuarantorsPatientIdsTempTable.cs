using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GuarantorsPatientIdsTempTable
{
    public long PatientId { get; set; }

    public string? AccountNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string FirstName { get; set; } = null!;

    public int PatientCountLinkedAsGaurantor { get; set; }

    public string? GuarantorPatientIds { get; set; }
}
