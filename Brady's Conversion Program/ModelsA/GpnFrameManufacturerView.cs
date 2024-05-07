using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameManufacturerView
{
    public long ManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }

    public long LocationId { get; set; }

    public bool? IsActive { get; set; }
}
