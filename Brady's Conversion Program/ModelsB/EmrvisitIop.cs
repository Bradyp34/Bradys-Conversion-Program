using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitIop
{
    public int TableId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? IopOd { get; set; }

    public string? IopOs { get; set; }

    public string? IopdeviceUsed { get; set; }

    public DateTime? IoptimeTaken { get; set; }

    public string? Iopnotes { get; set; }

    public string? IopccOd { get; set; }

    public string? IopccOs { get; set; }

    public decimal? CornealHysteresisOd { get; set; }

    public decimal? CornealHysteresisOs { get; set; }
}
