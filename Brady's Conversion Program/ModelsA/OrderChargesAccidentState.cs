using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderChargesAccidentState
{
    public long OrderChargesAccidentStateId { get; set; }

    public long OrderChargeId { get; set; }

    public short StateId { get; set; }

    public bool IsActive { get; set; }

    public long AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
