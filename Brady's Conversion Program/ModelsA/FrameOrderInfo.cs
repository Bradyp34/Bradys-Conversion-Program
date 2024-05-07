using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameOrderInfo
{
    public long FrameOrderInfoId { get; set; }

    public string Name { get; set; } = null!;

    public int MaterialId { get; set; }

    public int StatusId { get; set; }

    public int CptId { get; set; }

    public int EtypId { get; set; }

    public int FtypId { get; set; }

    public string Color { get; set; } = null!;

    public long ManufacturerId { get; set; }

    public int Eye { get; set; }

    public int Bridge { get; set; }

    public decimal A { get; set; }

    public decimal B { get; set; }

    public decimal Ed { get; set; }

    public decimal Dbl { get; set; }

    public decimal Csize { get; set; }

    public int TempleSize { get; set; }

    public int TempleStyleId { get; set; }

    public decimal Retail { get; set; }

    public long InventoryId { get; set; }

    public bool IsLmsframe { get; set; }
}
