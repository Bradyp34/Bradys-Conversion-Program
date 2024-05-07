using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwDesignToProcedureXref
{
    public long Id { get; set; }

    public long LabId { get; set; }

    public long DesignId { get; set; }

    public int CptId { get; set; }

    public decimal Fee { get; set; }

    public bool Active { get; set; }

    public long LocationId { get; set; }

    public int ProgressiveCptid { get; set; }

    public decimal ProgressiveFee { get; set; }
}
