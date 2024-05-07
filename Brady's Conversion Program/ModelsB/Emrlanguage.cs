using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrlanguage
{
    public int TableId { get; set; }

    public string? Description { get; set; }

    public string? Iso6392code { get; set; }

    public string? Iso6391code { get; set; }

    public short? Prioritize { get; set; }
}
