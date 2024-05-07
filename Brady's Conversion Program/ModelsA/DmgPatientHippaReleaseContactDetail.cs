using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientHippaReleaseContactDetail
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public string? Contact1FirstName { get; set; }

    public string? Contact1LastName { get; set; }

    public string? Contact1PhoneNumber { get; set; }

    public string? Contact2FirstName { get; set; }

    public string? Contact2LastName { get; set; }

    public string? Contact2PhoneNumber { get; set; }

    public string? Contact3FirstName { get; set; }

    public string? Contact3LastName { get; set; }

    public string? Contact3PhoneNumber { get; set; }
}
