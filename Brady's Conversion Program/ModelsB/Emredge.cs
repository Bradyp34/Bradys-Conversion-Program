using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emredge
{
    public int EmredgeId { get; set; }

    public string ComputerName { get; set; } = null!;

    public string IpAddressV4 { get; set; } = null!;

    public int Port { get; set; }

    public string? AuthKey { get; set; }

    public string? MachineKey { get; set; }
}
