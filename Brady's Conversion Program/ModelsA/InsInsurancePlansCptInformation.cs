using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsInsurancePlansCptInformation
{
    public int PlanCptId { get; set; }

    public int PlanId { get; set; }

    public int CptId { get; set; }

    public decimal AppliedValue { get; set; }

    public decimal CopayValue { get; set; }

    public int? AppliedTypeId { get; set; }

    public int? CopayTypeId { get; set; }
}
