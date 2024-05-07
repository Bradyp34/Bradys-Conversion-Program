using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientAlert
{
    public long AlertId { get; set; }

    public long PatientId { get; set; }

    public string? AlertMessage { get; set; }

    public short? PriorityId { get; set; }

    public DateTime? AlertCreatedDate { get; set; }

    public long? AlertCreatedBy { get; set; }

    public DateTime? AlertExpiryDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? AlertFlash { get; set; }
}
