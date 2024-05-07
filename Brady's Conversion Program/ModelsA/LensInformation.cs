using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensInformation
{
    public long LensId { get; set; }

    public string? Upc { get; set; }

    public decimal? LensThickness { get; set; }

    public decimal? Sphere { get; set; }

    public decimal? Cylinder { get; set; }

    public long? VendorId { get; set; }

    public long? ManufacturerId { get; set; }

    public int? ThicknessTypeId { get; set; }

    public int? LensEdgeId { get; set; }

    public int? PupilaryDistanceTypeId { get; set; }

    public long? LensMaterialId { get; set; }

    public int? SegmentHeightTypeId { get; set; }

    public int? LensBevelTypeId { get; set; }

    public int? CenterMeasureTypeId { get; set; }

    public int? LensTypeId { get; set; }

    public int? Cptid { get; set; }

    public long? LocationId { get; set; }

    public decimal? Cost { get; set; }

    public bool? Active { get; set; }

    public DateTime? DateAdded { get; set; }
}
