using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientSearchSchedule
{
    public int PtSearchScheduleId { get; set; }

    public int PtSearchId { get; set; }

    public int ScheduleId { get; set; }

    public int ExportDeviceId { get; set; }

    public DateTime? LastRun { get; set; }

    public bool IsActive { get; set; }
}
