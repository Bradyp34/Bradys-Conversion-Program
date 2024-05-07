using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetLocationsView
{
    public int SchedulingLocationId { get; set; }

    public string? SchedulingLocationCode { get; set; }

    public string? SchedulingLocationName { get; set; }

    public bool StaffLocationActive { get; set; }

    public long StaffLocationId { get; set; }

    public string StaffLocationName { get; set; } = null!;

    public bool IsSchedulingLocation { get; set; }
}
