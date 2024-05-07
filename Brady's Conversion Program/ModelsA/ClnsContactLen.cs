using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsContactLen
{
    public long ContactLensId { get; set; }

    public int ClnsBrandId { get; set; }

    public int? ClnsManufacturerId { get; set; }

    public string? Sphere { get; set; }

    public string? Cylinder { get; set; }

    public string? Axis { get; set; }

    public string? BaseCurve { get; set; }

    public string? Diameter { get; set; }

    public string? AddPower { get; set; }

    public string? AddPowerName { get; set; }

    public string? Multifocal { get; set; }

    public string? Color { get; set; }

    public string? Upc { get; set; }

    public int? ClnsLensTypeId { get; set; }

    public int? CptId { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsSoftContact { get; set; }

    public bool? IsActive { get; set; }

    public long? LocationId { get; set; }

    public int? LensPerBox { get; set; }

    public bool? IsLensFromClxCatalog { get; set; }
}
