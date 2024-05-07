using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FrameFtype
{
    public int FtypeId { get; set; }

    public string Ftype { get; set; } = null!;

    public string? Description { get; set; }

    public string? LabCode { get; set; }
}
