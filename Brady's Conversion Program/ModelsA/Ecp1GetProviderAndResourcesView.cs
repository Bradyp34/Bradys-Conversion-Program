using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetProviderAndResourcesView
{
    public long ResourceId { get; set; }

    public string ResourceName { get; set; } = null!;

    public string ResourceCode { get; set; } = null!;

    public string SpecialtyCode { get; set; } = null!;

    public string SpecialtyDescription { get; set; } = null!;

    public bool Active { get; set; }

    public long StaffLocationId { get; set; }

    public string StaffLocationName { get; set; } = null!;
}
