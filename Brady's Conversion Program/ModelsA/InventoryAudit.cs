using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InventoryAudit
{
    public int AuditId { get; set; }

    public string AuditName { get; set; } = null!;

    public DateTime AuditStartDate { get; set; }

    public string AuditUsers { get; set; } = null!;

    public DateTime AuditLastUpdateDate { get; set; }

    public bool IsAuditComplete { get; set; }

    public string? AuditRemarks { get; set; }

    public virtual ICollection<InventoryAuditDatum> InventoryAuditData { get; set; } = new List<InventoryAuditDatum>();
}
