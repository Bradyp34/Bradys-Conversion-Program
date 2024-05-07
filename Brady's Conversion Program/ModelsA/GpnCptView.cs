using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnCptView
{
    public int CptId { get; set; }

    public string? Cpt { get; set; }

    public string? Description { get; set; }

    public long? LocationId { get; set; }

    public int DepartmentId { get; set; }

    public int TypeOfServiceId { get; set; }

    public int TaxTypeId { get; set; }

    public decimal? CptFee { get; set; }

    public bool IsTaxable { get; set; }
}
