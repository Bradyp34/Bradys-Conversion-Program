using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CptTypeOfService
{
    public int TypeOfServiceId { get; set; }

    public string Code { get; set; } = null!;

    public int LocationId { get; set; }

    public bool Active { get; set; }

    public string Description { get; set; } = null!;
}
