using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsOrderTypeToLensStyleXref
{
    public long LmsOrderTypeToLensTypeXrefId { get; set; }

    public long OrderTypeId { get; set; }

    public long LensTypeId { get; set; }

    public bool IsActive { get; set; }
}
