using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GetBalanceDueOrdersView
{
    public long LabOrderId { get; set; }

    public int StatusId { get; set; }

    public long LocationId { get; set; }

    public bool? Active { get; set; }

    public int? Balance { get; set; }
}
