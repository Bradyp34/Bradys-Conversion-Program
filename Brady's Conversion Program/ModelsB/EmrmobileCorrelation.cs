using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrmobileCorrelation
{
    public int TableId { get; set; }

    public string Correlation { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateLastAccessed { get; set; }

    public string? AccessInfo { get; set; }

    public string? ClientId { get; set; }

    public int? EmpId { get; set; }

    public int? CurrentVisitId { get; set; }

    public int? CurrentPtId { get; set; }

    public short? Authenticated { get; set; }

    public short? LoggedIn { get; set; }

    public string? EmpFullName { get; set; }

    public string? ScreenSize { get; set; }

    public int? Switch { get; set; }

    public string? LastRequestInfo { get; set; }

    public string? CurrentPtInfo { get; set; }

    public string? CurrentVisitInfo { get; set; }
}
