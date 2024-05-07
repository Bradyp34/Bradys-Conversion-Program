using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class RxInformationToProcedureXref
{
    public long Id { get; set; }

    public decimal SphereMin { get; set; }

    public decimal SphereMax { get; set; }

    public decimal CylinderMin { get; set; }

    public decimal CylinderMax { get; set; }

    public int CptId { get; set; }

    public bool Bifocal { get; set; }

    public bool Trifocal { get; set; }

    public long LocationId { get; set; }
}
