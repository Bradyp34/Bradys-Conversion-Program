using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsLabInformation
{
    public int LmsLabId { get; set; }

    public string? LmsLabName { get; set; }

    public string? LmsLabAccountNum { get; set; }

    public string? LmsLabUrl { get; set; }

    public string? LmsLabUserName { get; set; }

    public string? LmsLabPassword { get; set; }

    public DateTime? LmsLabLastDownloadLensCatalog { get; set; }

    public string? CurrentRevisionLensCatalog { get; set; }

    public DateTime? LmsLabLastDownloadFrameCatalog { get; set; }

    public string? CurrentRevisionFrameCatalog { get; set; }

    public bool? IsActive { get; set; }

    public int LabId { get; set; }
}
