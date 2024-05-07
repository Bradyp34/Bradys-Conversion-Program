using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrfield
{
    public int FieldId { get; set; }

    public int? ControlId { get; set; }

    public string? Section { get; set; }

    public string? Tab { get; set; }

    public string? Table { get; set; }

    public string? TableField { get; set; }

    public string? LetterField { get; set; }

    public string? Field { get; set; }

    public short AllowInLetters { get; set; }

    public string? FormerFields { get; set; }
}
