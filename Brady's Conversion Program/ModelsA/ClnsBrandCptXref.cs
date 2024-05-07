using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsBrandCptXref
{
    public long BrandCptXrfId { get; set; }

    public long BrandId { get; set; }

    public long? CptId { get; set; }

    public long? LocationId { get; set; }
}
