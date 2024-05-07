using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingAppointmentTypesToResource
{
    public long AppointmentTypeId { get; set; }

    public int ResourceId { get; set; }

    public int Duration { get; set; }

    public bool IsSelected { get; set; }
}
