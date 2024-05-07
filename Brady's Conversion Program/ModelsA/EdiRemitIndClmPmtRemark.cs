using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmPmtRemark
{
    public long EdiRemitIndClmPmtRemarkId { get; set; }

    public long EdiRemitIndClmPmtId { get; set; }

    public long EdiMntRemitRemCodeId { get; set; }

    public string? EdiRemitIndClmMonetaryAmt { get; set; }

    public DateTime? AddedDate { get; set; }

    public bool? IsActive { get; set; }
}
