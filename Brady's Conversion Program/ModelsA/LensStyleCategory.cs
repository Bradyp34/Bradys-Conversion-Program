using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LensStyleCategory
{
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public bool Active { get; set; }
}
