using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensStyle
{
    public int StyleId { get; set; }

    public string StyleName { get; set; } = null!;

    public string? Description { get; set; }

    public int? LensStyleCategoriesId { get; set; }

    public string? LabCode { get; set; }
}
