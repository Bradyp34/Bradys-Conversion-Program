using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrexportDevice
{
    public int ExportDeviceId { get; set; }

    public string? Description { get; set; }

    public int? ExportDeviceType { get; set; }

    public string? ExportPath { get; set; }

    public int? PtIdtype { get; set; }

    public int? NamingConvention { get; set; }

    public int? SiteFilter { get; set; }

    public int? ProviderFilter { get; set; }

    public short? IncludeStylesheet { get; set; }

    public short? Active { get; set; }

    public int? ExportTrigger { get; set; }

    public string? InsertGuid { get; set; }
}
