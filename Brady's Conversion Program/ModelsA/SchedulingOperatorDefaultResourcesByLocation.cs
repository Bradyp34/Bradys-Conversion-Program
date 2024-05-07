using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingOperatorDefaultResourcesByLocation
{
    public int Id { get; set; }

    public long StaffId { get; set; }

    public long ResourceId { get; set; }

    public long LocationId { get; set; }
}
