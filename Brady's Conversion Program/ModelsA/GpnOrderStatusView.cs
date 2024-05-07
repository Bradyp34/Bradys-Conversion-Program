using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnOrderStatusView
{
    public int OrderStatusId { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string? OrderStatusDescription { get; set; }

    public bool OrderStatusActive { get; set; }
}
