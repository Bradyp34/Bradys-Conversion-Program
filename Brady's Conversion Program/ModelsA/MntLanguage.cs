using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntLanguage
{
    public short LanguageId { get; set; }

    public string Language { get; set; } = null!;

    public string? Code { get; set; }

    public bool? IsActive { get; set; }
}
