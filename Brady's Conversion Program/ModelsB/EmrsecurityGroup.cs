using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrsecurityGroup
{
    public int SecurityGroupId { get; set; }

    public string SecurityGroupName { get; set; } = null!;

    public string SecuritySettings { get; set; } = null!;

    public short IsActive { get; set; }

    public string? InsertGuid { get; set; }
}
