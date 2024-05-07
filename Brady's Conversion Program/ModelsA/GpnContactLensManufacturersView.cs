using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnContactLensManufacturersView
{
    public int ContactLensManufacturerId { get; set; }

    public string? ContactLensManufacturerName { get; set; }

    public string? ContactLensManufacturerCode { get; set; }

    public long? LocationId { get; set; }

    public bool? IsActive { get; set; }
}
