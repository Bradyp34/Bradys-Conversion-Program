using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensMaterial
{
    public long MaterialId { get; set; }

    public string Material { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }

    public decimal? MaterialIndex { get; set; }

    public int? MaterialCategoryId { get; set; }
}
