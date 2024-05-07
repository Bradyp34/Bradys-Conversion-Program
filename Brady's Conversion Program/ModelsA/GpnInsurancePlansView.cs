using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnInsurancePlansView
{
    public int PlanId { get; set; }

    public string PlanCode { get; set; } = null!;

    public string PlanDescription { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateOnly PlanStartDate { get; set; }

    public int PlanInsCompanyId { get; set; }
}
