using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntState
{
    public short StateId { get; set; }

    public string State { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public int CountryId { get; set; }

    public bool IsActive { get; set; }
}
