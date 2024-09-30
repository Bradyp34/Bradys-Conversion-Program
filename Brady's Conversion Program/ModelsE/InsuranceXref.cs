using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class InsuranceXref
{
    public int InsId { get; set; }

    public string? InsCode { get; set; }

    public string? NavCode { get; set; }

    public string? BriefName { get; set; }

    public string? CarrierName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? PayerId { get; set; }

    public string? MedicalVision { get; set; }
}
