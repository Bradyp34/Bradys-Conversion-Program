using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsOrderTypeToTintsXref
{
    public long LmsOrderTypeTintXrefId { get; set; }

    public long OrderTypeId { get; set; }

    public long TintId { get; set; }

    public bool IsActive { get; set; }
}
