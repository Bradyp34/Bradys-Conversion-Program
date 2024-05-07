using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagingModality
{
    public int ModalityId { get; set; }

    public string? Description { get; set; }

    public string? Abbr { get; set; }

    public int? Template { get; set; }

    public string? ModalityCodes { get; set; }

    public string? AcquisitionDeviceTypes { get; set; }

    public short? Prioritize { get; set; }

    public short? IsActive { get; set; }
}
