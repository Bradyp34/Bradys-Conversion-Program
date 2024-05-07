using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntSuffix
{
    public short SuffixId { get; set; }

    public string Suffix { get; set; } = null!;

    public bool IsActive { get; set; }
}
