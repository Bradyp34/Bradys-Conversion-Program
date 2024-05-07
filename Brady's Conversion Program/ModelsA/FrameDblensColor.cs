using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameDblensColor
{
    public long LensColorId { get; set; }

    public string ColorCode { get; set; } = null!;

    public string ColorDescription { get; set; } = null!;

    public int StatusId { get; set; }

    public long LocationId { get; set; }
}
