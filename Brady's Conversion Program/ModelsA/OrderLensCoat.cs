using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderLensCoat
{
    public long OrderLensCoatsId { get; set; }

    public long OrderId { get; set; }

    public long LensCoatId { get; set; }

    public string LensCoatType { get; set; } = null!;
}
