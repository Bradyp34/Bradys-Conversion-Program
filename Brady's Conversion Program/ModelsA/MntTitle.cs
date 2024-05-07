using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntTitle
{
    public short TitleId { get; set; }

    public string Title { get; set; } = null!;

    public bool IsActive { get; set; }
}
