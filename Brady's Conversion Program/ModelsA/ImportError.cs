using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImportError
{
    public long Uid { get; set; }

    public int LocationId { get; set; }

    public string? Identifier { get; set; }

    public string? ImportType { get; set; }

    public long? ErrorNumber { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime? ErrorTime { get; set; }
}
