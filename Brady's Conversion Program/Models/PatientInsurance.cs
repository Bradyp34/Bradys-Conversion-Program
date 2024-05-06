using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class PatientInsurance
{
    public int Id { get; set; }

    public string? PatientId { get; set; }

    public string? Code { get; set; }

    public string? Group { get; set; }

    public string? Cert { get; set; }

    public string? MedicalVision { get; set; }

    public string? Rank { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Copay { get; set; }

    public string? Deductible { get; set; }

    public string? Plan { get; set; }

    public string? PrimaryId { get; set; }

    public string? PrimaryFile { get; set; }
}
