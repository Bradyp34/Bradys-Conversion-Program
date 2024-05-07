using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwMaterialToProcedureXref
{
    public long Id { get; set; }

    public long LabId { get; set; }

    public long MaterialId { get; set; }

    public int CptId { get; set; }

    public decimal Fee { get; set; }

    public bool Active { get; set; }

    public long LocationId { get; set; }
}
