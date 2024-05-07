using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntMedicareSecondary
{
    public short MedicareSecondaryId { get; set; }

    public string? MedicareSecondaryName { get; set; }

    public string? MedicareSecondarryCode { get; set; }

    public string? MedicareSecondaryDescription { get; set; }

    public bool? IsActive { get; set; }
}
