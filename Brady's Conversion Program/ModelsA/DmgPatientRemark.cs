using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientRemark
{
    public long RemarkId { get; set; }

    public long PatientId { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? LastUpdated { get; set; }

    public bool? IsActive { get; set; }
}
