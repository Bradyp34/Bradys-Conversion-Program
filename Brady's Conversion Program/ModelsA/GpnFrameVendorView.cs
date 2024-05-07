using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnFrameVendorView
{
    public long VendorId { get; set; }

    public string? VendorName { get; set; }

    public string? VendorAccountRep { get; set; }

    public long LocationId { get; set; }

    public long? ManufacturerId { get; set; }
}
