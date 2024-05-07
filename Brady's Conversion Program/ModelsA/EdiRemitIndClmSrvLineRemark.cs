using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmSrvLineRemark
{
    public long EdiRemitIndClmSrvLineRmkId { get; set; }

    public long EdiRemitIndClmSrvLineId { get; set; }

    public long EdiMntRemitRemCodeId { get; set; }

    public DateTime AddedDate { get; set; }

    public bool IsActive { get; set; }
}
