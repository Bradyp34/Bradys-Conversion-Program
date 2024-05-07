using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingOperatorPermissionsBySchedulingLocation
{
    public int OperatorToBillingLocationId { get; set; }

    public int BillingLocationId { get; set; }

    public int StaffId { get; set; }

    public bool CreateAndModify { get; set; }

    public bool CancelAndReschedule { get; set; }

    public bool Force { get; set; }

    public bool Override { get; set; }

    public bool Recalls { get; set; }
}
