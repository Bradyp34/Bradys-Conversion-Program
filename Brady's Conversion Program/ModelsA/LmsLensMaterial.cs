using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsLensMaterial
{
    public long MaterialId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Active { get; set; }

    public int LocationId { get; set; }

    public long? DesignId { get; set; }

    public int LmsLabId { get; set; }

    public int? LabLensMaterialId { get; set; }

    public int? LabLensTypeId { get; set; }

    public int? LabLensLensId { get; set; }

    public int? LabLensCoatingId { get; set; }

    public int? LabLensColorId { get; set; }

    public bool? IsUpdated { get; set; }

    public bool? IsActive { get; set; }
}
