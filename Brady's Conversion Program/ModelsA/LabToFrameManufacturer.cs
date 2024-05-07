using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabToFrameManufacturer
{
    public int Uid { get; set; }

    public long ManufacturerId { get; set; }

    public long LabId { get; set; }

    public string? LabCode { get; set; }

    public long? LocationId { get; set; }

    public bool? Active { get; set; }
}
