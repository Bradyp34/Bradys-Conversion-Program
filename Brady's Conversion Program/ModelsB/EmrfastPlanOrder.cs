using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrfastPlanOrder
{
    public int FastPlanOrdersId { get; set; }

    public int? FastPlanId { get; set; }

    public string? FastPlanOrderDescription { get; set; }

    public string? FastPlanOrderWhen { get; set; }

    public int? FastPlanOrderTypeId { get; set; }

    public short? FastPlanOrderNeedsFollowup { get; set; }

    public string? FastPlanOrderRemarks { get; set; }

    public string? FastPlanCodeCpt { get; set; }

    public string? FastPlanCodeSnomed { get; set; }

    public int? FastPlanOrderModalityId { get; set; }

    public string? FastPlanCodeLoinc { get; set; }

    public string? FastPlanRefProviderFirstName { get; set; }

    public string? FastPlanRefProviderLastName { get; set; }

    public string? FastPlanRefProviderId { get; set; }

    public string? InsertGuid { get; set; }
}
