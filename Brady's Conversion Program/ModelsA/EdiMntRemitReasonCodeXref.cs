using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiMntRemitReasonCodeXref
{
    public int EdiMntRemitReasonCodeXrefId { get; set; }

    public int EdiMntRemitGroupCodeId { get; set; }

    public int EdiMntRemitReasonCodeId { get; set; }

    public bool? IsActive { get; set; }
}
