using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetPatientProvidersView
{
    public int PatientProviderId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? ProviderCode { get; set; }

    public bool? IsActive { get; set; }

    public bool IsReferringProvider { get; set; }
}
