using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingRecallInformationBySequence
{
    public int Id { get; set; }

    public long AppointmentTypeId { get; set; }

    public int RecallNumber { get; set; }

    public int IntervalValue { get; set; }

    public int IntervalTypeId { get; set; }

    public int IntervalTypeId2 { get; set; }

    public string? RecallNotes { get; set; }
}
