using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsPackage
{
    public int PackageId { get; set; }

    public int LabId { get; set; }

    public string Name { get; set; } = null!;

    public bool DoNotUsePackageCpt { get; set; }

    public int CptId { get; set; }

    public decimal Fee { get; set; }

    public string SpecialInstructions { get; set; } = null!;

    public string FramesNotes { get; set; } = null!;

    public int OrderTypeId { get; set; }

    public int LensTypeId { get; set; }

    public int DesignId { get; set; }

    public int MaterialId { get; set; }

    public int TintId { get; set; }

    public int TintTypeId { get; set; }

    public long LocationId { get; set; }

    public bool Active { get; set; }

    public bool FrameIncluded { get; set; }
}
