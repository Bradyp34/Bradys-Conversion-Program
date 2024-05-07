using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensRxInfo
{
    public long LensRxInfoId { get; set; }

    public decimal Sphere { get; set; }

    public decimal Cylinder { get; set; }

    public int Axis { get; set; }

    public decimal Distant { get; set; }

    public decimal Near { get; set; }

    public int FormId { get; set; }

    public int IoId { get; set; }

    public decimal IoPrism { get; set; }

    public int UdId { get; set; }

    public decimal UdPrism { get; set; }

    public int Bsize { get; set; }

    public decimal Base { get; set; }

    public decimal PrismFee { get; set; }

    public decimal PrismUnits { get; set; }
}
