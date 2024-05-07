using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ReceiptAdNote
{
    public long ReceiptAdId { get; set; }

    public string AdNote { get; set; } = null!;

    public int LocationId { get; set; }

    public bool Active { get; set; }

    public int SortOrder { get; set; }
}
