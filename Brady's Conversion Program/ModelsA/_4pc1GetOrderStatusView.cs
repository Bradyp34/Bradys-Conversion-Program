using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class _4pc1GetOrderStatusView
{
    public int StatusId { get; set; }

    public string? Status { get; set; }

    public bool? IsDefaultStatus { get; set; }

    public string ProductPickUpXrefStatusType { get; set; } = null!;
}
