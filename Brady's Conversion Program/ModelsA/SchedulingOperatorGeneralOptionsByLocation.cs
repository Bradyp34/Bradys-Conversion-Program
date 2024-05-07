using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingOperatorGeneralOptionsByLocation
{
    public int Id { get; set; }

    public long StaffId { get; set; }

    public int TimeIntervalId { get; set; }

    public int IntervalStartValue { get; set; }

    public int IntervalStartTypeId { get; set; }

    public int IntervalEndValue { get; set; }

    public int IntervalEndTypeId { get; set; }

    public bool CanViewMaintenance { get; set; }

    public bool CanImportData { get; set; }

    public bool CanAccessSchedulingReports { get; set; }

    public bool CanAccessRecallReports { get; set; }

    public long LocationId { get; set; }
}
