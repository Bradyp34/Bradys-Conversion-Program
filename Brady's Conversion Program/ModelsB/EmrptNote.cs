using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrptNote
{
    public int PtNotesId { get; set; }

    public int? PtId { get; set; }

    public int? EmpId { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedDate { get; set; }

    public short? ShowInVisitSummary { get; set; }

    public string? InsertGuid { get; set; }
}
