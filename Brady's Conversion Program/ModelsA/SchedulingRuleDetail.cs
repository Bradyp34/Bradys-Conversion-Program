using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SchedulingRuleDetail
{
    public int RuleDetailId { get; set; }

    public int RuleId { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int AppointmentTypeId { get; set; }

    public int Duration { get; set; }

    public int LocationId { get; set; }

    public int MaxAppointments { get; set; }

    public int BillingLocationId { get; set; }

    public bool WebSchedule { get; set; }
}
