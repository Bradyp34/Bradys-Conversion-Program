using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiMntClmStatus
{
    public int EdiMntClmStatusId { get; set; }

    public string? EdiMntClmStatusCd { get; set; }

    public string? EdiMntClmStatusDesc { get; set; }

    public bool? IsActive { get; set; }
}
