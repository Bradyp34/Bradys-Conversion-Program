using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrrecall
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public string? ClientSoftwarePtId { get; set; }

    public int? LocationId { get; set; }

    public int? ProviderEmpId { get; set; }

    public int? RefProviderEmpId { get; set; }

    public string? ResourceId { get; set; }

    public DateTime RecallDateTime { get; set; }

    public string? Notes { get; set; }

    public string? RecallType { get; set; }

    public string? Ddpstatus { get; set; }

    public string? InsertGuid { get; set; }
}
