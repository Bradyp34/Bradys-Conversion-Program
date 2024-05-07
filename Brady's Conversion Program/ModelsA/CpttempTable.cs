using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CpttempTable
{
    public string? Cpt { get; set; }

    public string? AlternateCode { get; set; }

    public string? Invalidcol { get; set; }

    public string? Description { get; set; }

    public decimal? Fee { get; set; }

    public int? TypeOfServiceId { get; set; }

    public int? DepartmentId { get; set; }
}
