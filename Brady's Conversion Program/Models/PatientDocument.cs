using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class PatientDocument
{
    public int Id { get; set; }

    public string? PatientId { get; set; }

    public string? DocumentImageType { get; set; }

    public string? DocumentDescription { get; set; }

    public string? DocumentNotes { get; set; }

    public string? FilePathName { get; set; }

    public string? PatientInsuranceCompany { get; set; }

    public string? Date { get; set; }
}
