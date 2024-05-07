using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrdicomdevice
{
    public int DicomdeviceId { get; set; }

    public string? Description { get; set; }

    public string? Aetitle { get; set; }

    public string? Ip { get; set; }

    public int? Port { get; set; }
}
