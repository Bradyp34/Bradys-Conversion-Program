using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsOrderTypeToTintTypeXref
{
    public long LmsOrderTypeToTintTypeXrefId { get; set; }

    public long OrderTypeId { get; set; }

    public long TintTypeId { get; set; }

    public bool IsActive { get; set; }
}
