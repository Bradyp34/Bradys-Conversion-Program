using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Iop
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? Iopod { get; set; }

    public string? Iopos { get; set; }

    public string? IopdeviceUsed { get; set; }

    public string? IoptimeTaken { get; set; }

    public string? Iopnotes { get; set; }

    public string? Iopccod { get; set; }

    public string? Iopccos { get; set; }

    public string? CornealHysteresisOd { get; set; }

    public string? CornealHysteresisOs { get; set; }

    public string? Active { get; set; }
}
