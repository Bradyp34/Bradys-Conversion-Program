using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnPaymentTypesView
{
    public long PaymentTypeId { get; set; }

    public string PaymentTypeCode { get; set; } = null!;

    public string PaymentTypeDescription { get; set; } = null!;

    public long PaymentTypeLocationId { get; set; }
}
