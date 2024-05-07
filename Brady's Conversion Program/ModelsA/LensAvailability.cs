using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensAvailability
{
    public long Uid { get; set; }

    public long? MaterialId { get; set; }

    public int? StyleId { get; set; }

    public long? CoatId { get; set; }

    public long? ColorId { get; set; }

    public long? LabId { get; set; }
}
