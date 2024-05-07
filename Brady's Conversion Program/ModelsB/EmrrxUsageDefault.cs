using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrrxUsageDefault
{
    public int RxusageId { get; set; }

    public string? MedName { get; set; }

    public string? DefaultSig { get; set; }

    public string? DefaultDisp { get; set; }

    public string? DefaultRefill { get; set; }

    public short? DefaultDispType { get; set; }

    public int? RxUsageType { get; set; }

    public string? DefaultDispUnitType { get; set; }

    public string? DefaultRxRemarks { get; set; }

    public string? InsertGuid { get; set; }

    public short BrandMedOnly { get; set; }
}
