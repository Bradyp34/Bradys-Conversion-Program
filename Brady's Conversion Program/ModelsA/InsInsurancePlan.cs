using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsInsurancePlan
{
    public int PlanId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public bool DefaultPlan { get; set; }

    public DateOnly PlanStartDate { get; set; }

    public int InsCompanyId { get; set; }
}
