using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntCountry
{
    public short CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public bool Active { get; set; }
}
