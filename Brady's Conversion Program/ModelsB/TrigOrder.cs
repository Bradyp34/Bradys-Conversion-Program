using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class TrigOrder
{
    public long Id { get; set; }

    public int VisitOrderId { get; set; }

    public int VisitId { get; set; }

    public int? PtId { get; set; }

    public string? AccountNumber { get; set; }

    public DateTime? CreatedTime { get; set; }

    public bool? RowUpdated { get; set; }

    public bool? Isprocessed { get; set; }

    public DateTime? ReplyTime { get; set; }

    public bool? ReplyProcessed { get; set; }
}
