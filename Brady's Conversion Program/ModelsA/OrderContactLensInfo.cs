using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderContactLensInfo
{
    public long OrderContactLensInfoId { get; set; }

    public int BrandId { get; set; }

    public string? Power { get; set; }

    public string? BaseCurve { get; set; }

    public string? Diameter { get; set; }

    public string? Cylinder { get; set; }

    public string? Axis { get; set; }

    public string? AddPower { get; set; }

    public int? AddDescription { get; set; }

    public string? Color { get; set; }

    public string? Pupil { get; set; }

    public string? VaDistance { get; set; }

    public string? VaNear { get; set; }

    public int? CptId { get; set; }

    public int? Units { get; set; }

    public long? InventoryId { get; set; }

    public bool? ContactLensDispensed { get; set; }

    public DateTime? ContactLensDispensedDateTime { get; set; }

    public int? MultiFocal { get; set; }
}
