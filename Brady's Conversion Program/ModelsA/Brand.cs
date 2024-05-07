using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Brand
{
    public long BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public int StatusId { get; set; }

    public long LocationId { get; set; }
}
