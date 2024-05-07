using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrschedule
{
    public int ScheduleId { get; set; }

    public DateTime ScheduleTime { get; set; }

    public int ScheduleType { get; set; }

    public int? ScheduledDay { get; set; }

    public bool IsRecurring { get; set; }

    public string InsertGuid { get; set; } = null!;
}
