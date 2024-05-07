using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientConsentDetail
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public int FormId { get; set; }

    public string ConsentMarkDown { get; set; } = null!;

    public string Signature { get; set; } = null!;

    public DateTime RecordAddedDatetime { get; set; }
}
