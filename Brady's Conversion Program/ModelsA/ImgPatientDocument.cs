using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgPatientDocument
{
    public long DocumentId { get; set; }

    public long? DocumentOwnerId { get; set; }

    public long? PatientId { get; set; }

    public short? DocumentType { get; set; }

    public string? DocumentName { get; set; }

    public string? DocumentRemarks { get; set; }

    public string? DocumentRoot { get; set; }

    public string? DocumentLocation { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? AddedBy { get; set; }

    public bool? IsActive { get; set; }
}
