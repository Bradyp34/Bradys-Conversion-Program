using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrsmartApp
{
    public int SmartAppId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Path { get; set; } = null!;

    public short AllowPatientLaunch { get; set; }

    public short AllowPractitionerLaunch { get; set; }

    public string? InsertGuid { get; set; }
}
