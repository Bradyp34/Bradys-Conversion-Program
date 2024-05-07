using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ecp1GetSettingsView
{
    public long StaffLocationId { get; set; }

    public string StaffLocationName { get; set; } = null!;

    public bool WebScheduleActive { get; set; }

    public bool AutomaticallyConvertRequestToAppointment { get; set; }

    public bool AppointmentsReminderAndCancellationActive { get; set; }

    public bool RecallsActive { get; set; }

    public bool ProductPickUpActive { get; set; }
}
