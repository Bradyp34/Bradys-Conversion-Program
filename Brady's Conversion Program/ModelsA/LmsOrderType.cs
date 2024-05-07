using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsOrderType
{
    public long OrderTypeId { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public int? LabOrderTypeId { get; set; }

    public int LmsLabId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsUpdated { get; set; }
}
