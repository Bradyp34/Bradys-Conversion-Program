using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsManufacturer
{
    public int ClnsManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }

    public string? ManufacturerCode { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? LocationId { get; set; }

    public bool? IsActive { get; set; }
}
