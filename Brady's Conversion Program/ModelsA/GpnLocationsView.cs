using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnLocationsView
{
    public long LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public string? Address1 { get; set; }

    public string Address2 { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZiPcode { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string ContactName { get; set; } = null!;

    public int LocationType { get; set; }

    public string DisplayName { get; set; } = null!;
}
