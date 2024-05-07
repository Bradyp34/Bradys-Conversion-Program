using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderService
{
    public long OrderServicesId { get; set; }

    public long OrderId { get; set; }

    public int ServiceId { get; set; }

    public string Description { get; set; } = null!;

    public int ServiceNumber { get; set; }
}
