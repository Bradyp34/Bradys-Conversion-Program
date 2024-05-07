using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgPatientPhoto
{
    public long PhotoId { get; set; }

    public long? PatientId { get; set; }

    public string? PhotoLocationRoot { get; set; }

    public string? PhotoLocation { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? InfProcessed { get; set; }
}
