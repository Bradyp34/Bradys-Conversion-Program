using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PaymentType
{
    public long PaymentTypeId { get; set; }

    public string PaymentTypeCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public long LocationId { get; set; }
}
