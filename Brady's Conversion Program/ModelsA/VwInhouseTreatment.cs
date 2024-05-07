﻿using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwInhouseTreatment
{
    public long TreatmentId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }
}
