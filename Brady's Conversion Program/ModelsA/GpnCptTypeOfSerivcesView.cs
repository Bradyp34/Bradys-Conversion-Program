using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnCptTypeOfSerivcesView
{
    public int TypeOfServiceId { get; set; }

    public string Code { get; set; } = null!;

    public string TypeOfServiceDescription { get; set; } = null!;

    public int LocationId { get; set; }

    public bool IsActive { get; set; }
}
