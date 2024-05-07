using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntContactPreference
{
    public short ContactPreferenceId { get; set; }

    public string? ContactPreferenceName { get; set; }

    public string? ContactPreferenceCode { get; set; }

    public bool? IsActive { get; set; }
}
