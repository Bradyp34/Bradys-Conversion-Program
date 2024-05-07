using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeFormsRulesInformation
{
    public long Id { get; set; }

    public int FormId { get; set; }

    public int AppointmentTypeId { get; set; }

    public int TriggerFormValue { get; set; }

    public int TriggerFormTypeId { get; set; }

    public int LocationId { get; set; }

    public int FormSameDayTriggerTypeId { get; set; }
}
