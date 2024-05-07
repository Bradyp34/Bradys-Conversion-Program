using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PrismSetting
{
    public int ProcedureId { get; set; }

    public decimal Fee { get; set; }

    public int CategoryId { get; set; }

    public int TypeId { get; set; }

    public int? LocationId { get; set; }
}
