using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrcodeSystem
{
    public int CodeSystemId { get; set; }

    public string Description { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string? Oid { get; set; }

    public string? Uri { get; set; }

    public string? Hl7id { get; set; }
}
