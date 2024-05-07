using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxAndProcedureCrossReference
{
    public int TaxListId { get; set; }

    public int Cptid { get; set; }

    public bool Selected { get; set; }
}
