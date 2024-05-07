using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsMaterialToProcedureXref
{
    public long Id { get; set; }

    public int LabId { get; set; }

    public string Code { get; set; } = null!;

    public int CptId { get; set; }

    public decimal Fee { get; set; }

    public bool Active { get; set; }

    public long LocationId { get; set; }
}
