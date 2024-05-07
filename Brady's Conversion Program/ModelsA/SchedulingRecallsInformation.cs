using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingRecallsInformation
{
    public long RecallInformationId { get; set; }

    public long AppointmentTypeId { get; set; }

    public int RecallTypeId { get; set; }

    public int NumberOfRecalls { get; set; }

    public bool HasEquivalentIntervals { get; set; }

    public int? IntervalValue { get; set; }

    public int? IntervalTypeId { get; set; }

    public string EqualIntervalRecallNotes { get; set; } = null!;
}
