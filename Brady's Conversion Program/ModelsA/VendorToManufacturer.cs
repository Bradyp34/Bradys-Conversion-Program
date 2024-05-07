using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VendorToManufacturer
{
    public long VendorToManufacturerId { get; set; }

    public long VendorId { get; set; }

    public long ManufacturerId { get; set; }
}
