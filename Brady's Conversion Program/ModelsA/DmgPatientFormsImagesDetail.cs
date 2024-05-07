using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientFormsImagesDetail
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public string? DriversLicensePath { get; set; }

    public string? MedicalInsurance1PdfPath { get; set; }

    public string? MedicalInsurance2PdfPath { get; set; }

    public string? VisionInsurance1PdfPath { get; set; }

    public DateTime RecordAddedDatetime { get; set; }
}
