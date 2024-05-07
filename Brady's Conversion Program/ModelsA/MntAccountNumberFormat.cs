using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntAccountNumberFormat
{
    public short FormatId { get; set; }

    public string Format { get; set; } = null!;

    public string? FormatDescription { get; set; }

    public string? FormatExample { get; set; }

    public string? FormatAdditionalParameter { get; set; }

    public bool IsActive { get; set; }
}
