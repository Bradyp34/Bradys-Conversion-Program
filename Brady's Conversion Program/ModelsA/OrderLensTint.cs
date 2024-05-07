using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderLensTint
{
    public long OrderLensTintsId { get; set; }

    public long OrderId { get; set; }

    public int TintId { get; set; }

    public string TintDescription { get; set; } = null!;
}
