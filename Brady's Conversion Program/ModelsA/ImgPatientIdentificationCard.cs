using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgPatientIdentificationCard
{
    public long IdentificationCardId { get; set; }

    public long? CardOwnerId { get; set; }

    public long? PatientId { get; set; }

    public short? IdentificationCardType { get; set; }

    public string? IdentificationCardName { get; set; }

    public string? IdentificationCardRemarks { get; set; }

    public string? IdentificationCardRoot { get; set; }

    public string? IdentificationCardLocation { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public bool? IsActive { get; set; }
}
