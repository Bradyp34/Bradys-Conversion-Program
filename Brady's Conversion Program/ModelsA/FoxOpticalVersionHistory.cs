using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FoxOpticalVersionHistory
{
    public long FoxOpticalVersionId { get; set; }

    public string VersionNo { get; set; } = null!;

    public DateTime VersionDate { get; set; }

    public string? VersionCopyright { get; set; }
}
