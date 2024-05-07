using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrlock
{
    public int LockId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public string? FormName { get; set; }

    public int? EmpId { get; set; }

    public DateTime? LockTime { get; set; }

    public string? Pcname { get; set; }

    public string? PcuserName { get; set; }

    public string? OperatingSystemName { get; set; }
}
