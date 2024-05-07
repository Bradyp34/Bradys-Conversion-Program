using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsBrand
{
    public int ClnsBrandId { get; set; }

    public string? BrandName { get; set; }

    public string? BrandCode { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? LocationId { get; set; }

    public bool? IsActive { get; set; }
}
