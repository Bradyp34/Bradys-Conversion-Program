using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingAppointmentTypesGrouping
{
    public long ParentAppointmentTypeId { get; set; }

    public long ChildAppointmentTypeId { get; set; }
}
