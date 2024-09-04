using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameVendor
{
    public long Id { get; set; }

    public string? OldVendorId { get; set; }

    public string? VendorName { get; set; }

    public string? VendorAccount { get; set; }

    public string? VendorAgent { get; set; }

    public string? VendorWebSite { get; set; }

    public string? VendorEmail { get; set; }

    public string? LocationId { get; set; }

    public string? Active { get; set; }
}
