using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InventoryAuditDatum
{
    public int AuditDataId { get; set; }

    public long InventoryId { get; set; }

    public int FrameCount { get; set; }

    public string User { get; set; } = null!;

    public int AuditId { get; set; }

    public virtual InventoryAudit Audit { get; set; } = null!;
}
