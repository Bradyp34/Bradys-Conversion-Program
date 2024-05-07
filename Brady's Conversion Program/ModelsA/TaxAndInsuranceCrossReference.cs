using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxAndInsuranceCrossReference
{
    public int TaxListId { get; set; }

    public int InsuranceCompanyId { get; set; }

    public bool Selected { get; set; }

    public bool SendToInsurance { get; set; }
}
