using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ProductPuckupOrderStatusInformation
{
    public int ProductReceivedOrderStatusId { get; set; }

    public int ProductNotifiedOrderStatusId { get; set; }

    public int ProductPickedUpOrderStatusId { get; set; }

    public int ProductCancelledOrderStatusId { get; set; }

    public DateOnly? DefaultOrdersStartDate { get; set; }

    public int ClProductReceivedOrderStatusId { get; set; }

    public int ClProductNotifiedOrderStatusId { get; set; }

    public int ClProductPickedUpOrderStatusId { get; set; }

    public int ClProductCancelledOrderStatusId { get; set; }
}
