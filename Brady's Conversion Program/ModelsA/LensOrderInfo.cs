using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensOrderInfo
{
    public long LensOrderInfoId { get; set; }

    public int LensStyleId { get; set; }

    public long MaterialId { get; set; }

    public long ColorId { get; set; }

    public int Add { get; set; }

    public decimal SegHt { get; set; }

    public decimal Thck { get; set; }

    public int EcId { get; set; }

    public decimal Ocht { get; set; }

    public int ModeId { get; set; }

    public int Add2 { get; set; }

    public int EncId { get; set; }

    public decimal ChargeAmount { get; set; }
}
